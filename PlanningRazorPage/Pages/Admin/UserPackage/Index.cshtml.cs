using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.User.UserPackage;
using PlanningRazorPage.Services.User;
using PlanningRazorPage.Services.User.UserPackage;
using System.Diagnostics;

namespace PlanningRazorPage.Pages.Admin.UserPackage
{
    public class IndexModel : BaseRazorFilter<UsersPackagesFilterParam>
    {
        private readonly IUserPackageService _service;

        public IndexModel(IUserPackageService service)
        {
            _service = service;
        }

        public UsersPackagesFilterResult? Users { get; set; }
        public async Task OnGet(int pageId = 1,int take = 8, bool activePackage = false,
            DateTime? filterStartTime = null, DateTime? filterEndTime = null)
        {
            Users = await _service.GetFilterUserPackages(new UsersPackagesFilterParam
            {
                //packageId = pageId,
                packageTitle = FilterParams.packageTitle,
                Take = take,
                PageId = pageId,
                phoneNumber = FilterParams.phoneNumber,
                search = FilterParams.search,
                userName = FilterParams.userName,
                ActivePackages = activePackage,
                FilterEndTime = filterEndTime ?? DateTime.MaxValue,
                FilterStartTime = filterStartTime ?? DateTime.MinValue
            });
        }
    }
}
