using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using PlanningRazorPage.Infrastructure;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Role;
using PlanningRazorPage.Services.Role;

namespace PlanningRazorPage.Pages.Admin.Role
{
    public class EditModel : BaseRazorPage
    {
        private readonly IRoleService _roleService;

        public EditModel(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [BindProperty(SupportsGet = true)]
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<Permission> Permissions { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null)
                return RedirectToPage("Roles");

            Name = role.Name;
            Permissions = role.Permissions;
            return Page();
        }

        public async Task<IActionResult> OnPost(string id, List<Permission> permissions)
        {
            var result = await _roleService.EditRole(new EditRoleCommand()
            {
                Name = Name,
                Permissions = permissions,
                Id = id
            });

            // return RedirectAndShowAlert(result, RedirectToPage("Roles"), RedirectToPage("Edit", new { id }));
            return RedirectAndShowAlert(result, RedirectToPage("roles"));
        }
    }
}