#region Using
using Lombiq.SimpleAnalytics.Models;
#endregion

namespace Lombiq.SimpleAnalytics.ViewModels {
    public class AnalyticsSettingsViewModel : IAnalyticsSettingsPart {
        #region IAnalyticsSettingsPart Members
        public string AnalyticsScript { get; set; }
        public bool IncludeOnAdmin { get; set; }
        #endregion
    }
}
