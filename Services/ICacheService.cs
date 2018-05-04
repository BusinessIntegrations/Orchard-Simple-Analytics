#region Using
using Lombiq.SimpleAnalytics.Models;
using Orchard;
#endregion

namespace Lombiq.SimpleAnalytics.Services {
    public interface ICacheService : IDependency {
        #region Methods
        ICacheModel GetData();
        IAnalyticsSettingsPart GetSettings();
        void ReleaseCache();
        void UpdateSettings(IAnalyticsSettingsPart settings);
        #endregion
    }
}
