using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Role;
using PlanningRazorPage.Services.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlanningRazorPage.Pages.Admin.Role
{
    public class RolesModel : BaseRazorFilter<RoleFilterParam>
    {
        private readonly IRoleService _service;
        public RolesModel(IRoleService service)
        {
            _service = service;
        }
        [BindProperty(SupportsGet = true)]
        public RoleFilterResult FilterResult { get; set; }

        public async Task OnGet(int pageId = 1, int take = 8, string? Name = null)
        {
            FilterResult = await _service.GetRoleByFilter(new RoleFilterParam()
            {
                PageId = pageId,
                Take = take,
                Name = Name,
            });
        }
        public void OnPost()
        {
        }
    }
}
