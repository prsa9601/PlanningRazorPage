using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Role;

namespace PlanningRazorPage.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "Role";

        public RoleService(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<RoleDto?>> GetRoles()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<RoleDto?>>>($"{ModuleName}");
            return result?.Data;
        }

        public async Task<RoleDto?> GetRoleById(string roleId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<RoleDto?>>($"{ModuleName}/{roleId}");
            return result?.Data;
        }

        public async Task<RoleFilterResult?> GetRoleByFilter(RoleFilterParam filterParams)
        {
            var url = $"{ModuleName}/filter?PageId={filterParams.PageId}&Take={filterParams.Take}";

            if (filterParams.Name != null)
                url += $"&title={filterParams.Name}";

            var result = await _client.GetFromJsonAsync<ApiResult<RoleFilterResult?>>(url);
            return result?.Data;
        }

        public async Task<ApiResult> CreateRole(CreateRoleCommand command)
        {
            var result = await _client.PostAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditRole(EditRoleCommand command)
        {
            var result = await _client.PutAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> DeleteRole(string id)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{id}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
