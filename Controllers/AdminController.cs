#region Using
using System.Web.Mvc;
using Lombiq.SimpleAnalytics.Models;
using Lombiq.SimpleAnalytics.Services;
using Lombiq.SimpleAnalytics.ViewModels;
using Orchard;
using Orchard.Localization;
using Orchard.Themes;
using Orchard.UI.Admin;
using Orchard.UI.Notify;
#endregion

namespace Lombiq.SimpleAnalytics.Controllers {
    [Themed]
    [Admin]
    public class AdminController : Controller {
        private readonly ICacheService _cacheService;
        private readonly IOrchardServices _orchardServices;

        public AdminController(IOrchardServices orchardServices, ICacheService cacheService) {
            _orchardServices = orchardServices;
            _cacheService = cacheService;
            T = NullLocalizer.Instance;
        }

        #region Properties
        public Localizer T { get; set; }
        #endregion

        #region Methods
        public ActionResult Index() {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageSimpleAnalytics, T(Constants.CannotManageText))) {
                return new HttpUnauthorizedResult();
            }

            var viewModel = GetViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(AnalyticsSettingsViewModel viewModel) {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageSimpleAnalytics, T(Constants.CannotManageText))) {
                return new HttpUnauthorizedResult();
            }

            if (ModelState.IsValid) {
                if (TryUpdateModel(viewModel)) {
                    UpdateData(viewModel);
                    _orchardServices.Notifier.Information(T("Analytics settings saved successfully."));
                    _orchardServices.Notifier.Information(T("Remember if you are using the Output Cache that you need to clear it."));
                }
                else {
                    _orchardServices.Notifier.Information(T("Could not save Analytics settings."));
                }
            }
            else {
                _orchardServices.Notifier.Error(T(Constants.ValidationErrorText));
                return View(viewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        ///     Retrieves cached data and converts to viewmodel
        /// </summary>
        /// <returns></returns>
        private AnalyticsSettingsViewModel GetViewModel() {
            var cacheModel = _cacheService.GetSettings();
            return new AnalyticsSettingsViewModel {
                AnalyticsScript = cacheModel.AnalyticsScript,
                IncludeOnAdmin = cacheModel.IncludeOnAdmin
            };
        }

        private void UpdateData(IAnalyticsSettingsPart model) {
            _cacheService.UpdateSettings(model);
        }
        #endregion
    }
}
