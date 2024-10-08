using PlanningRazorPage.Infrastructure;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.RegisterApiServices();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation()
    .AddRazorPagesOptions(options =>
    {
        // options.Conventions.AuthorizeFolder("/Profile", "Account");
        options.Conventions.AuthorizeFolder("/SellerPanel", "SellerPanel");
    });

//builder.Services.AddAuthentication(option =>
//{
//    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
//    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//});
builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.Use(async (context, next) =>
{
    var token = context.Request.Cookies["token"]?.ToString();
    if (string.IsNullOrWhiteSpace(token) == false)
    {
        context.Request.Headers.Append("Authorization", $"Bearer {token}");
    }
    await next();
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.Use(async (context, next) =>
{
    await next();
    var status = context.Response.StatusCode;
    if (status == 401)
    {
        var path = context.Request.Path;
        context.Response.Redirect($"../../../../auth/login?redirectTo={path}");
    }
});
app.UseAuthentication();


//app.UseAuthorization();
//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "Default", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapAreaControllerRoute(name: "AdminPanel", areaName: "Admin1", pattern: "CodeYad{controller-Home}/{action-Index}/{id?}");
});
app.MapRazorPages();

app.Run();