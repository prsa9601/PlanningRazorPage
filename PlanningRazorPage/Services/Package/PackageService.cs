using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Friend;
using PlanningRazorPage.Models.Package;

namespace PlanningRazorPage.Services.Package;

public class PackageService : IPackageService
{
    private readonly HttpClient _client;
    //private readonly IHttpContextAccessor _accessor;
    private const string ModuleName = "Package";

    public PackageService(HttpClient client)
    {
        _client = client;
        //_accessor = accessor;, IHttpContextAccessor accessor
    }

    public async Task<ApiResult> Add(AddPackageCommand command)
    {
        var result = await _client.PostAsJsonAsync($"{ModuleName}", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> Edit(EditPackageCommand command)
    {
        var result = await _client.PatchAsJsonAsync($"{ModuleName}", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> Delete(RemovePackageCommand command)
    {
        var result = await _client.DeleteAsync($"{ModuleName}/{command}");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    
    public async Task<ApiResult> SetImage(SetImagePackageCommand command)
    {
        var result = await _client.PostAsJsonAsync($"{ModuleName}", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();

    }

    public async Task<ApiResult> SetSpecification(SetSpecificationPackageCommand command)
    {
        var result = await _client.PostAsJsonAsync($"{ModuleName}", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<List<PackageDto?>> GetListPackages()
    {
        var result = await _client.GetFromJsonAsync<ApiResult<List<PackageDto>?>>($"{ModuleName}");
        return result?.Data;
    }

    public async Task<PackageDto?> GetPackage(long id)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<PackageDto?>>($"{ModuleName}");
        return result?.Data;
    }
}