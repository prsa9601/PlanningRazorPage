using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Services.User;

namespace PlanningRazorPage.Pages.Front.Profile
{
    [BindProperties]
    //[Authorize]
    public class ProfileModel : PageModel
    {
        private readonly IUserService _service;

        public ProfileModel(IUserService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet()
        {
            //  if (!User.Identity.IsAuthenticated)
            //     return Redirect("/auth/login");
            return Page();
        }
        public async void OnGetCurrentUser()
        {
            var result = _service.GetByCurrentUser();
            return;
            Page();
        }
    }
}
