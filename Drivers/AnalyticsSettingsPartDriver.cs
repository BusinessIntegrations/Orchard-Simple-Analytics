#region Using
using Lombiq.SimpleAnalytics.Models;
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;
using Orchard.UI.Notify;
#endregion

namespace Lombiq.SimpleAnalytics.Drivers {
    public class AnalyticsSettingsPartDriver : ContentPartDriver<AnalyticsSettingsPart> {
        private readonly INotifier _notifier;
        private readonly ISignals _signals;

        public AnalyticsSettingsPartDriver(ISignals signals, INotifier notifier) {
            _signals = signals;
            _notifier = notifier;
            T = NullLocalizer.Instance;
        }

        #region Properties
        public Localizer T { get; set; }
        #endregion

        #region Methods
        protected override DriverResult Editor(AnalyticsSettingsPart part, dynamic shapeHelper) {
            return Editor(part, null, shapeHelper);
        }

        protected override DriverResult Editor(AnalyticsSettingsPart part, IUpdateModel updater, dynamic shapeHelper) {
            return ContentShape("Parts_AnalyticsSettings_SiteSettings_Edit",
                    () => {
                        if (updater != null) {
                            if (updater.TryUpdateModel(part, Prefix, null, null)) {
                                _notifier.Add(NotifyType.Information, T("Remember if you are using the Output Cache that you need to clear it."));
                                _signals.Trigger(Constants.LombiqSimpleAnalyticsChanged);
                            }
                        }
                        return shapeHelper.EditorTemplate(TemplateName: "Parts.AnalyticsSettings.SiteSettings", Model: part, Prefix: Prefix);
                    })
                .OnGroup(Constants.AdminMenuName);
        }
        #endregion
    }
}
