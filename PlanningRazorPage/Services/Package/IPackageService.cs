using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Package;

namespace PlanningRazorPage.Services.Package
{
    public interface IPackageService
    {
        Task<ApiResult> Add(AddPackageCommand command);
        Task<ApiResult> Edit(EditPackageCommand command);
        Task<ApiResult> Delete(RemovePackageCommand command);
        Task<ApiResult> SetImage(SetImagePackageCommand command);
        Task<ApiResult> SetSpecification(SetSpecificationPackageCommand command);

        Task<List<PackageDto?>> GetListPackages();
        Task<PackageDto?> GetPackage(long id);

    }
}
