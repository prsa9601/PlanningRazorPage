using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Models.User.UserPackage;
using PlanningRazorPage.Services.Package;
using PlanningRazorPage.Services.User.UserPackage;

namespace PlanningRazorPage.Pages.Admin.UserPackage
{
    public class UserPackagesDetailModel : BaseRazorFilter<UsersPackagesByUserIdFilterParam>
    {
        private readonly IUserPackageService _service;

        public UserPackagesDetailModel(IUserPackageService service)
        {
            _service = service;
        }
        public UsersPackagesByUserIdFilterResult? Users { get; set; }
        public async Task<IActionResult> OnGet(string userId = "", DateTime? filterEndTime = null
            , DateTime? filterStartTime = null, int take = 8, int pageId = 1,
            bool activePackages = false, SearchUserPackage search = SearchUserPackage.None)
        {
            Users = await _service.GetFilterUserPackagesByUserId(new UsersPackagesByUserIdFilterParam
            {
                UserId = userId,
                FilterEndTime = filterEndTime ?? DateTime.MaxValue,
                ActivePackages = activePackages,
                FilterStartTime = filterStartTime ?? DateTime.MinValue,
                PageId = pageId,
                search = search,
                Take = take,
            });
            return Page();
        }
    }
}
