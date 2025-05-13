using Microsoft.AspNetCore.Mvc;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Services.Package;
using PlanningRazorPage.Services.User;
using PlanningRazorPage.Services.User.UserPackage;
using SetUserPackageCommand = PlanningRazorPage.Models.User.UserPackage.SetUserPackageCommand;

namespace PlanningRazorPage.Pages.Admin.UserPackage
{
    public class SetPackagesModel : BaseRazorPage
    {
        private readonly IUserPackageService _service;
        private readonly IPackageService _packageService;
        private readonly IUserService _userService;

        public SetPackagesModel(IUserPackageService service, IUserService userService, IPackageService packageService)
        {
            _service = service;
            _userService = userService;
            _packageService = packageService;
        }

        public class InputClass
        {
            public string id { get; set; } = String.Empty;
        }
        [BindProperty(SupportsGet = true)]
        public InputClass Input { get; set; } = new InputClass();
        public List<PackageDto>? Packages { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {
            Packages = await _packageService.GetPackagesByUserId(id);
            Input = new InputClass { id = id };
            return Page();
        }
        public async Task<IActionResult> OnPost(long packageId)
        {
            var result = await _service.SetActivePackage(new SetUserPackageCommand()
            {
                userId = Input.id,
                packageId = packageId
            });
            return RedirectAndShowAlert(result,Redirect("Index"));
        }
    }
}
