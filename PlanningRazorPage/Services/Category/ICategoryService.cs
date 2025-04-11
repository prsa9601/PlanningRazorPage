using PlanningRazorPage.Models.Category;
using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Blog;

namespace PlanningRazorPage.Services.Category
{
    public interface ICategoryService
    {
        Task<ApiResult?> Create(CreateCategoryCommand command);
        Task<ApiResult?> Edit(EditCategoryCommand command);
        Task<ApiResult?> Delete(long CategoryId);
        Task<List<CategoryDto?>> GetList();
        Task<CategoryDto?> GetById(long CategoryId);
    }
    internal class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "Category";

        public CategoryService(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResult?> Create(CreateCategoryCommand command)
        {
            var result = await _client.PostAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> Delete(long CategoryId)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/DeleteCategory?CategoryId={CategoryId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> Edit(EditCategoryCommand command)
        {
            var result = await _client.PatchAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<CategoryDto?> GetById(long CategoryId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<CategoryDto?>>($"{ModuleName}/GetCategoryById?CategoryId={CategoryId}");
            return result?.Data;
        }

        public async Task<List<CategoryDto?>> GetList()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<CategoryDto?>>>($"{ModuleName}/GetListCategory");
            return result?.Data!;
        }
    }
}
