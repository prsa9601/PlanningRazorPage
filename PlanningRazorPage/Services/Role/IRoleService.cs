using PlanningRazorPage.Models.Role;
using PlanningRazorPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace PlanningRazorPage.Services.Role
{
    public interface IRoleService
    {
        Task<List<RoleDto?>> GetRoles();
        Task<RoleDto?> GetRoleById(string roleId);
        Task<RoleFilterResult?> GetRoleByFilter(RoleFilterParam filterParams);
        Task<ApiResult> CreateRole(CreateRoleCommand command);
        Task<ApiResult> EditRole(EditRoleCommand command);

        Task<ApiResult> DeleteRole(string id);


    }
}
