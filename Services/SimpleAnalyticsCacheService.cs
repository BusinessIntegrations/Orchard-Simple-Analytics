#region Using
using Lombiq.SimpleAnalytics.Models;
using Orchard;
using Orchard.Caching;
using Orchard.ContentManagement;
#endregion

namespace Lombiq.SimpleAnalytics.Services {
    public class SimpleAnalyticsCacheService : ISimpleAnalyticsCacheService {
        private readonly ICacheManager _cacheManager;
        private readonly IOrchardServices _orchardServices;
        private readonly ISignals _signals;

        public SimpleAnalyticsCacheService(ICacheManager cacheManager, IOrchardServices orchardServices, ISignals signals) {
            _cacheManager = cacheManager;
            _orchardServices = orchardServices;
            _signals = signals;
        }

        #region ISimpleAnalyticsCacheService Members
        public CacheHelper GetScript() {
            return _cacheManager.Get(Constants.LombiqSimpleAnalyticsCacheKey,
                context => {
                    context.Monitor(_signals.When(Constants.LombiqSimpleAnalyticsChanged));
                    var analyticsSettingsPart = _orchardServices.WorkContext.CurrentSite.As<AnalyticsSettingsPart>();
                    var settingsAnalyticsScript = analyticsSettingsPart.AnalyticsScript;
                    var script = "<script type=\"text/javascript\">" + settingsAnalyticsScript + "</script>";
                    return new CacheHelper(script, analyticsSettingsPart.IncludeOnAdmin);
                });
        }
        #endregion
    }
}
