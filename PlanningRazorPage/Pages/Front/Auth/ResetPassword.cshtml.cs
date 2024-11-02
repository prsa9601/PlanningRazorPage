using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlanningRazorPage.Pages.Front.Auth
{
    [Authorize]
    public class NewPasswordModel : PageModel
    {

        public void OnGet()
        {
            //if (User.Identity.IsAuthenticated)
            //{

            //}
                //return Redirect("/");
        }
    }
}
