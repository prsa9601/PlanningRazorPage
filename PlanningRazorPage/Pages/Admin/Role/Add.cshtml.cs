using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using PlanningRazorPage.Infrastructure;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Infrastructure.Utils;
using PlanningRazorPage.Models.Role;
using PlanningRazorPage.Services.Role;

namespace PlanningRazorPage.Pages.Admin.Role
{
    public class AddModel : BaseRazorPage
    {
        private readonly IRoleService _roleService;

        public AddModel(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [BindProperty]
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(string[] permission)
        {
            var permissionModel = new List<Permission>();
            try
            {
                foreach (var item in permission)
                {
                    permissionModel.Add(EnumUtils.ParseEnum<Permission>(item));
                }
            }
            catch 
            {
                //
            }

            var result = await _roleService.CreateRole(new CreateRoleCommand()
            {
                Name = Title,
                Permissions = permissionModel
            });
            return RedirectAndShowAlert(result, RedirectToPage("roles"));
        }
    }
}
