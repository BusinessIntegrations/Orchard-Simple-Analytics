#region Using
using System.Web.Mvc;
using Lombiq.SimpleAnalytics.Services;
using Orchard.Mvc.Filters;
using Orchard.UI.Admin;
using Orchard.UI.Resources;
#endregion

namespace Lombiq.SimpleAnalytics.Filters {
    public class AnalyticsScriptInjectingFilter : FilterProvider, IResultFilter {
        private readonly ICacheService _cacheService;
        private readonly IResourceManager _resourceManager;

        public AnalyticsScriptInjectingFilter(IResourceManager resourceManager, ICacheService cacheService) {
            _resourceManager = resourceManager;
            _cacheService = cacheService;
        }

        #region IResultFilter Members
        public void OnResultExecuted(ResultExecutedContext filterContext) { }

        public void OnResultExecuting(ResultExecutingContext filterContext) {
            // Should only run on a full view rendering result only.
            if (!(filterContext.Result is ViewResult)) {
                return;
            }

            var isAdmin = AdminFilter.IsApplied(filterContext.RequestContext);
            var cacheModel = _cacheService.GetData();
            if ((!isAdmin || cacheModel.IncludeOnAdmin) &&
                !string.IsNullOrEmpty(cacheModel.Script)) {
                _resourceManager.RegisterHeadScript(cacheModel.Script);
            }
        }
        #endregion
    }
}
