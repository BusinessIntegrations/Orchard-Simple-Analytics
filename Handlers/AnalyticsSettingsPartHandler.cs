#region Using
using Lombiq.SimpleAnalytics.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;
#endregion

namespace Lombiq.SimpleAnalytics.Handlers {
    public class AnalyticsSettingsPartHandler : ContentHandler {
        public AnalyticsSettingsPartHandler() {
            Filters.Add(new ActivatingFilter<AnalyticsSettingsPart>("Site"));
            T = NullLocalizer.Instance;
        }

        #region Properties
        public Localizer T { get; set; }
        #endregion

        #region Methods
        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            if (context.ContentItem.ContentType != "Site") {
                return;
            }
            base.GetItemMetadata(context);
            context.Metadata.EditorGroupInfo.Add(new GroupInfo(T(Constants.AdminMenuName)) {
                Position = "1"
            });
        }
        #endregion
    }
}
