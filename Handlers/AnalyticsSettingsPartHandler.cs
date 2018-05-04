#region Using
using Lombiq.SimpleAnalytics.Models;
using Orchard.ContentManagement.Handlers;
#endregion

namespace Lombiq.SimpleAnalytics.Handlers {
    public class AnalyticsSettingsPartHandler : ContentHandler {
        public AnalyticsSettingsPartHandler() {
            Filters.Add(new ActivatingFilter<AnalyticsSettingsPart>(Constants.SiteContentTypeName));
        }
    }
}
