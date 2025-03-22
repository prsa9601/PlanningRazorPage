using PlanningRazorPage.Infrastructure;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Role;
using PlanningRazorPage.Models.User;
using PlanningRazorPage.Services.Role;
using PlanningRazorPage.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlanningRazorPage.Pages.Admin.User
{
    [Authorize]
    public class SetRolesModel : BaseRazorPage
    {
        private readonly IRoleService _service;
        private readonly IUserService _userService;
        
        public SetRolesModel(IRoleService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }
        // public List<RoleDto> roles { get; set; }
        [BindProperty]
        public string Id { get; set; }

        [BindProperty]
        public List<UserRoleDto> role { get; set; }
        public async Task OnGet(string id)
        {
            Id = id;
            // roles = await _service.GetRoles();
            var users = await _userService.GetById(id);
            role = users.Roles;
        }
        //public async Task OnGet(string id)
        //{
        //    Id = id;
        //    // roles = await _service.GetRoles();
        //    var users = await _userService.GetById(id);
        //    role = users.Roles;
        //}
        public async Task<IActionResult> OnPost(List<string> role)
        {
            var result = await _userService.SetRole(new Models.User.SetUserRoleCommand()
            {
                //userId = User.GetUserId(),
                userId = Id,
                rolesId = role
            });
            return RedirectAndShowAlert(result,Redirect("Index"));
        }
    }
}
