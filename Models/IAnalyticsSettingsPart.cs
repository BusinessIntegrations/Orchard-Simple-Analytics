namespace Lombiq.SimpleAnalytics.Models {
    public interface IAnalyticsSettingsPart {
        #region Properties
        string AnalyticsScript { get; }
        bool IncludeOnAdmin { get; }
        #endregion
    }
}
