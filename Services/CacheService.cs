﻿#region Using
using Lombiq.SimpleAnalytics.Models;
using Orchard;
using Orchard.Caching;
using Orchard.ContentManagement;
#endregion

namespace Lombiq.SimpleAnalytics.Services {
    public class CacheService : ICacheService {
        private readonly ICacheManager _cacheManager;
        private readonly IOrchardServices _orchardServices;
        private readonly ISignals _signals;

        public CacheService(ICacheManager cacheManager, IOrchardServices orchardServices, ISignals signals) {
            _cacheManager = cacheManager;
            _orchardServices = orchardServices;
            _signals = signals;
        }

        #region ICacheService Members
        public ICacheModel GetData() {
            return _cacheManager.Get(Constants.CacheKey,
                context => {
                    context.Monitor(_signals.When(Constants.CacheTrigger));
                    var part = GetSettingsPart();
                    return new CacheModel(part.AnalyticsScript, part.IncludeOnAdmin);
                });
        }

        public IAnalyticsSettingsPart GetSettings() {
            return GetSettingsPart();
        }

        public void ReleaseCache() {
            _signals.Trigger(Constants.CacheTrigger);
        }

        public void UpdateSettings(IAnalyticsSettingsPart settings) {
            var part = GetSettingsPart();
            part.AnalyticsScript = settings.AnalyticsScript;
            part.IncludeOnAdmin = settings.IncludeOnAdmin;
            ReleaseCache();
        }
        #endregion

        #region Methods
        private AnalyticsSettingsPart GetSettingsPart() {
            return _orchardServices.WorkContext.CurrentSite.As<AnalyticsSettingsPart>();
        }
        #endregion
    }
}
