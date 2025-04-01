using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Package;

namespace PlanningRazorPage.Services.Package
{
    public interface IPackageService
    {
        Task<ApiResult?> Add(AddPackageCommand command);
        Task<ApiResult?> Edit(EditPackageCommand command);
        Task<ApiResult> Delete(long id);
        Task<ApiResult> SetImage(SetImagePackageCommand command);
        Task<ApiResult> SetSpecification(SetSpecificationPackageCommand command);
        Task<ApiResult> SetActivePackage(SetActivePackageCommand command);
        Task<ApiResult> RemoveActivePackage(RemoveActivePackageCommand command);

        Task<List<PackageDto?>> GetListPackages();
        Task<List<PackageDtoForUserProfile?>> GetListActiveForCurrentUser();
        Task<List<PackageDto>?> GetPackagesByUserId(string UserId);
        Task<PackageDto?> GetPackage(long id);

    }
}
