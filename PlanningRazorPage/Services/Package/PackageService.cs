using Newtonsoft.Json;
using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Friend;
using PlanningRazorPage.Models.Package;
using System.Text;

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

    public async Task<ApiResult?> Add(AddPackageCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.Title.ToString()), "Title");
        formData.Add(new StringContent(command.Link.ToString()), "Link");
        formData.Add(new StringContent(command.Price.ToString()), "Price");
        formData.Add(new StreamContent(command.Picture.OpenReadStream()), "Picture", command.Picture.FileName);
        
        var specifications = JsonConvert.SerializeObject(command.Specifications);
        formData.Add(new StringContent(specifications, Encoding.UTF8, "application/json"), "Specifications");

        
        var result = await _client.PostAsync($"{ModuleName}", formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> Edit(EditPackageCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.Title.ToString()), "Title");
        formData.Add(new StringContent(command.Id.ToString()), "Id");
        formData.Add(new StringContent(command.Link.ToString()), "Link");
        formData.Add(new StringContent(command.Price.ToString()), "Price");
        formData.Add(new StreamContent(command.Picture.OpenReadStream()), "Picture", command.Picture.FileName);

        var specifications = JsonConvert.SerializeObject(command.Specifications);
        formData.Add(new StringContent(specifications, Encoding.UTF8, "application/json"), "Specifications");

        var result = await _client.PatchAsync($"{ModuleName}", formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> Delete(long id)
    {
        var result = await _client.DeleteAsync($"{ModuleName}/{id}");
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

    public async Task<ApiResult> SetActivePackage(SetActivePackageCommand command)
    {
        var result = await _client.PostAsJsonAsync($"{ModuleName}/SetActivePackage", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> RemoveActivePackage(RemoveActivePackageCommand command)
    {
        var result = await _client.PatchAsJsonAsync($"{ModuleName}/RemoveActivePackage",command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<List<PackageDto?>> GetListPackages()
    { 
        var result = await _client.GetFromJsonAsync<ApiResult<List<PackageDto>?>>($"{ModuleName}/GetList");
        return result?.Data!;
    }

    public async Task<PackageDto?> GetPackage(long id)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<PackageDto?>>($"{ModuleName}/GetById?id={id}");
        return result?.Data;
    }
}