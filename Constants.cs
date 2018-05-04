#region Using
using Lombiq.SimpleAnalytics.Controllers;
#endregion

namespace Lombiq.SimpleAnalytics {
    public static class Constants {
        public const string AdminControllerName = "Admin";
        public const string AdminMenuName = "Simple Analytics";
        public const string AnalyticsSettings = "AnalyticsSettings";
        public const string AreaName = "Lombiq.SimpleAnalytics";
        public const string BiMenuSection = "bi-menu-section";
        public const string CacheKey = "Lombiq.SimpleAnalytics.CacheKey";
        public const string CacheTrigger = "Lombiq.SimpleAnalytics.Changed";
        public const string CannotManageText = "Can't manage Simple Analytics Settings";
        public const string IndexActionName = nameof(AdminController.Index);
        public const string SiteContentTypeName = "Site";
        public const string SiteSettings = "SiteSettings";
        public const string ValidationErrorText = "Validation error";
    }
}
