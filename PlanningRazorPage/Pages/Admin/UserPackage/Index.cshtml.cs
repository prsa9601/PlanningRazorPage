using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.User.UserPackage;

namespace PlanningRazorPage.Pages.Admin.UserPackage
{
    public class IndexModel : BaseRazorFilter<UsersPackagesFilterParam>
    {
        public UsersPackagesFilterResult Users { get; set; }
        public void OnGet()
        {
        }
    }
}
