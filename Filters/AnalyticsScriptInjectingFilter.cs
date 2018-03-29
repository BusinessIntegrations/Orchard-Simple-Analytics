#region Using
using System.Web.Mvc;
using Lombiq.SimpleAnalytics.Services;
using Orchard.Mvc.Filters;
using Orchard.UI.Admin;
using Orchard.UI.Resources;
#endregion

namespace Lombiq.SimpleAnalytics.Filters {
    public class AnalyticsScriptInjectingFilter : FilterProvider, IResultFilter {
        private readonly IResourceManager _resourceManager;
        private readonly ISimpleAnalyticsCacheService _simpleAnalyticsCacheService;

        public AnalyticsScriptInjectingFilter(IResourceManager resourceManager, ISimpleAnalyticsCacheService simpleAnalyticsCacheService) {
            _resourceManager = resourceManager;
            _simpleAnalyticsCacheService = simpleAnalyticsCacheService;
        }

        #region IResultFilter Members
        public void OnResultExecuted(ResultExecutedContext filterContext) { }

        public void OnResultExecuting(ResultExecutingContext filterContext) {
            // Should only run on a full view rendering result only.
            if (!(filterContext.Result is ViewResult)) {
                return;
            }
            var isAdmin = AdminFilter.IsApplied(filterContext.RequestContext);
            var cacheHelper = _simpleAnalyticsCacheService.GetScript();
            if ((!isAdmin || cacheHelper.IncludeInAdmin) &&
                !string.IsNullOrEmpty(cacheHelper.Script)) {
                _resourceManager.RegisterHeadScript(cacheHelper.Script);
            }
        }
        #endregion
    }
}
