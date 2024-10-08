using PlanningRazorPage.Models.Auth;
using PlanningRazorPage.Models;

namespace PlanningRazorPage.Services.Auth
{
    public interface IAuthService
    {
        //Task<ApiResult<LoginResponse>?> Login(LoginCommand command);
        Task<ApiResult?> Login(LoginCommand command);
        Task<ApiResult?> Register(RegisterCommand command);
        Task<ApiResult?> Logout();
    }
}
