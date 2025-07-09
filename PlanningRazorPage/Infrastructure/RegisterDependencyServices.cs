using PlanningRazorPage.Infrastructure.CookieUtils;
using PlanningRazorPage.Infrastructure.FileUtil.Interfaces;
using PlanningRazorPage.Infrastructure.FileUtil.Services;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Services.Auth;
using PlanningRazorPage.Services.Blog;
using PlanningRazorPage.Services.Category;
using PlanningRazorPage.Services.Comment;
using PlanningRazorPage.Services.Event;
using PlanningRazorPage.Services.Friend;
using PlanningRazorPage.Services.Notification;
using PlanningRazorPage.Services.Package;
using PlanningRazorPage.Services.Request;
using PlanningRazorPage.Services.Role;
using PlanningRazorPage.Services.SocialMedia.Instagram;
using PlanningRazorPage.Services.SocialMedia.Telegram;
using PlanningRazorPage.Services.User;
using PlanningRazorPage.Services.User.UserNotification;
using PlanningRazorPage.Services.User.UserPackage;

namespace PlanningRazorPage.Infrastructure;

public static class RegisterDependencyServices
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {
        var baseAddress = "http://localhost:5009/api/";

        services.AddHttpContextAccessor();

        services.AddScoped<HttpClientAuthorizationDelegatingHandler>();
        services.AddTransient<IRenderViewToString, RenderViewToString>();
        services.AddTransient<IFileService, FileService>();


        // اضافه کردن TelegramService به DI
        //services.AddScoped<ITelegramService, TelegramService>();

        // services.AddAutoMapper(typeof(RegisterDependencyServices).Assembly);
        //services.AddScoped<IMainPageService, MainPageService>();

        services.AddScoped<ShopCartCookieManager>();

        //services.AddCookieManager();

        services.AddHttpClient<IAuthService, AuthService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
        
        services.AddHttpClient<IUserPackageService, UserPackageService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
        
        services.AddHttpClient<IUserNotificationService, UserNotificationService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ITelegramService, TelegramService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
        
        services.AddHttpClient<IInstagramService, InstagramService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
           
        services.AddHttpClient<INotificationService, NotificationService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
        
        services.AddHttpClient<ICommentService, CommentService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
        
        services.AddHttpClient<ICategoryService, CategoryService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IBlogService, BlogService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
        
        services.AddHttpClient<IRoleService, RoleService>(httpClient =>
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


