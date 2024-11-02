using PlanningRazorPage.Infrastructure.CookieUtils;
using PlanningRazorPage.Infrastructure.FileUtil.Interfaces;
using PlanningRazorPage.Infrastructure.FileUtil.Services;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Services.Auth;
using PlanningRazorPage.Services.Event;
using PlanningRazorPage.Services.Friend;
using PlanningRazorPage.Services.Package;
using PlanningRazorPage.Services.Request;
using PlanningRazorPage.Services.User;

namespace PlanningRazorPage.Infrastructure;

public static class RegisterDependencyServices
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {
        var baseAddress = "http://localhost:5131/api/";

        services.AddHttpContextAccessor();

        services.AddScoped<HttpClientAuthorizationDelegatingHandler>();
        services.AddTransient<IRenderViewToString, RenderViewToString>();
        services.AddTransient<IFileService, FileService>();

       // services.AddAutoMapper(typeof(RegisterDependencyServices).Assembly);
        //services.AddScoped<IMainPageService, MainPageService>();

        services.AddScoped<ShopCartCookieManager>();

        //services.AddCookieManager();

        services.AddHttpClient<IAuthService, AuthService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IEventService, EventService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IUserService, UserService >(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IFriendService, FriendService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IRequestService, RequestService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IPackageService, PackageService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();


        return services;
    }
}


