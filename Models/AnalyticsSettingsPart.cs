#region Using
using Orchard.ContentManagement;
#endregion

namespace Lombiq.SimpleAnalytics.Models {
    public class AnalyticsSettingsPart : ContentPart {
        #region Properties
        public string AnalyticsScript { get { return this.Retrieve(x => x.AnalyticsScript); } set { this.Store(x => x.AnalyticsScript, value); } }
        public bool IncludeOnAdmin { get { return this.Retrieve(x => x.IncludeOnAdmin); } set { this.Store(x => x.IncludeOnAdmin, value); } }
        #endregion
    }
}
