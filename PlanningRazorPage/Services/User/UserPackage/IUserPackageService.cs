using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Models.Request;
using PlanningRazorPage.Models.User.UserPackage;
using System.Text;

namespace PlanningRazorPage.Services.User.UserPackage
{
    public interface IUserPackageService
    {
        Task<ApiResult?> SetActivePackage(SetUserPackageCommand command);
        Task<ApiResult?> EditUserPackage(EditUserPackageCommand command);
        Task<ApiResult?> DeActiveUserPackage(DeActiveUserPackageCommand command);
        Task<List<UserPackageDto>?> GetPackageCurrentUser();
        Task<UsersSinglePackagesDto?> GetPackageByUserId(string userId, long packageId);
        Task<UsersPackagesFilterResult?> GetFilterUserPackages(UsersPackagesFilterParam param);
        Task<UsersPackagesByUserIdFilterResult?> GetFilterUserPackagesByUserId(UsersPackagesByUserIdFilterParam param);
    }
    internal class UserPackageService : IUserPackageService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "UserPackage";
        public UserPackageService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult?> DeActiveUserPackage(DeActiveUserPackageCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/DeActivePackageForUser", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> EditUserPackage(EditUserPackageCommand command)
        {
            var result = await _client.PatchAsJsonAsync($"{ModuleName}", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<UsersPackagesFilterResult?> GetFilterUserPackages(UsersPackagesFilterParam param)
        {
            string path = $"{ModuleName}/GetFilterPackageUser?PageId={param.PageId}&Take={param.Take}";
            //if (param.packageId > 0)
            //    path += $"&packageId={param.packageId}";
            if (param.packageTitle != null)
                path += $"&packageTitle={param.packageTitle}";
            if (param.userName != null)
                path += $"&userName={param.userName}";
            if (param.phoneNumber != null)
                path += $"&phoneNumber={param.phoneNumber}";
            if (param.FilterStartTime != DateTime.MinValue)
                path += $"&FilterStartTime={param.FilterStartTime}";
            if (param.FilterEndTime != DateTime.MaxValue)
                path += $"&filterEndTime={param.FilterEndTime}";
            if (param.ActivePackages == true)
                path += $"&ActivePackages={param.ActivePackages}";
            //var f = param.search switch
            //{
            //    SearchUserPackage.Latest => path += "",
            //    SearchUserPackage.None => path += "",
            //    _ => path += "",
            //};
            switch (param.search)
            {
                case SearchUserPackage.None:
                    path += $"&search=0";
                    break;
                case SearchUserPackage.Latest:
                    path += $"&search=1";
                    break;
                default:
                    path += $"&search=0";
                    break;
            }

            var result = await _client.GetFromJsonAsync
                <ApiResult<UsersPackagesFilterResult>>(path);
            return result?.Data;
        }

        public async Task<UsersSinglePackagesDto?> GetPackageByUserId(string userId, long packageId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<UsersSinglePackagesDto?>>($"{ModuleName}/GetPackageByUserId");
            return result?.Data;
        }

        public async Task<List<UserPackageDto>?> GetPackageCurrentUser()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<UserPackageDto>?>>($"{ModuleName}/GetPackageCurrentUser");
            return result?.Data;
        }

        public async Task<ApiResult?> SetActivePackage(SetUserPackageCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/SetPackageForUser", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<UsersPackagesByUserIdFilterResult?> GetFilterUserPackagesByUserId(UsersPackagesByUserIdFilterParam param)
        {
            string path = $"{ModuleName}/GetFilterPackageUserByUserId?PageId={param.PageId}&Take={param.Take}";
            if (!string.IsNullOrEmpty(param.UserId))
                path += $"&UserId={param.UserId}";
            if (param.FilterStartTime != DateTime.MinValue)
                path += $"&FilterStartTime={param.FilterStartTime}";
            if (param.FilterEndTime != DateTime.MaxValue)
                path += $"&filterEndTime={param.FilterEndTime}";
            if (param.ActivePackages == true)
                path += $"&ActivePackages={param.ActivePackages}";
            //var f = param.search switch
            //{
            //    SearchUserPackage.Latest => path += "",
            //    SearchUserPackage.None => path += "",
            //    _ => path += "",
            //};
            switch (param.search)
            {
                case SearchUserPackage.None:
                    path += $"&search=0";
                    break;
                case SearchUserPackage.Latest:
                    path += $"&search=1";
                    break;
                default:
                    path += $"&search=0";
                    break;
            }

            var result = await _client.GetFromJsonAsync
                <ApiResult<UsersPackagesByUserIdFilterResult>>(path);
            return result?.Data;
        }
    }
}
