using Newtonsoft.Json;
using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Blog;

namespace PlanningRazorPage.Services.Blog
{
    public interface IBlogService
    {
        Task<ApiResult> Create(AddBlogCommand command);
        Task<ApiResult> Edit(EditBlogCommand command);
        Task<ApiResult> Remove(long BlogId);
        Task<ApiResult> IncreaseVisit(IncreaseBlogVisitCommand command);
        Task<BlogDto?> GetBlogById(long BlogId);
        Task<BlogDto?> GetBlogBySlug(string Slug);
        Task<BlogFilterResult> GetBlogByFilter(BlogFilterParam filterParams);
    }
    internal class BlogService : IBlogService
    {
        private readonly HttpClient _client;

        private const string ModuleName = "Blog";
        public BlogService(HttpClient client)
        {
            _client = client;
        }


        public async Task<ApiResult> Create(AddBlogCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Slug.ToString()), "Slug");
            formData.Add(new StringContent(command.Description.ToString()), "Description");
            formData.Add(new StringContent(command.CategoryId.ToString()), "CategoryId");
            formData.Add(new StringContent(command.CreatorUserName.ToString()), "CreatorUserName");
            formData.Add(new StringContent(command.Title.ToString()), "Title");
            formData.Add(new StringContent(command.SeoData.MetaTitle), "MetaTitle");
            formData.Add(new StringContent(command.SeoData.MetaDescription), "MetaDescription");
            formData.Add(new StringContent(command.SeoData.MetaKeyWords), "MetaKeyWords");
            formData.Add(new StringContent(command.SeoData.IndexPage.ToString()), "IndexPage");
            formData.Add(new StringContent(command.SeoData.Canonical), "Canonical");
            formData.Add(new StringContent(command.SeoData.Schema), "Schema");
            //formData.Add(new StringContent(JsonConvert.SerializeObject(command.SeoData)), "SeoData");
            formData.Add(new StreamContent(command.Image.OpenReadStream()), "ImageName", command.Image.FileName);
            formData.Add(new StringContent(command.IsSend.ToString()),"IsSend");
            formData.Add(new StringContent(command.SendTime.ToString("o")), "SendTime");
            var result = await _client.PostAsync($"{ModuleName}/CreateBlog", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> Edit(EditBlogCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Slug.ToString()), "Slug");
            formData.Add(new StringContent(command.BlogId.ToString()), "BlogId");
            formData.Add(new StringContent(command.Description.ToString()), "Description");
            formData.Add(new StringContent(command.CategoryId.ToString()), "CategoryId");
            formData.Add(new StringContent(command.CreatorUserName.ToString()), "CreatorUserName");
            formData.Add(new StringContent(command.Title.ToString()), "Title");
            //formData.Add(new StringContent(JsonConvert.SerializeObject(command.SeoData)), "SeoData");
            formData.Add(new StreamContent(command.Image.OpenReadStream()), "ImageName", command.Image.FileName);
            formData.Add(new StringContent(command.IsSend.ToString()), "IsSend");
            formData.Add(new StringContent(command.SendTime.ToString("o")), "SendTime");

            formData.Add(new StringContent(command.SeoData.MetaTitle), "MetaTitle");
            formData.Add(new StringContent(command.SeoData.MetaDescription), "MetaDescription");
            formData.Add(new StringContent(command.SeoData.MetaKeyWords), "MetaKeyWords");
            formData.Add(new StringContent(command.SeoData.IndexPage.ToString()), "IndexPage");
            formData.Add(new StringContent(command.SeoData.Canonical), "Canonical");
            formData.Add(new StringContent(command.SeoData.Schema), "Schema");
            var result = await _client.PatchAsync($"{ModuleName}/EditBlog", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<BlogFilterResult> GetBlogByFilter(BlogFilterParam filterParams)
        {
            var url = $"{ModuleName}/GetBlogByFilter?PageId={filterParams.PageId}&Take={filterParams.Take}";

            if (filterParams.Title != null)
                url += $"&Title={filterParams.Title}";

            if (filterParams.Slug != null)
                url += $"&Slug={filterParams.Slug}";

            if (filterParams.Search != null)
                url += $"&Search={filterParams.Search}";

            if (filterParams.CategoryId != null && filterParams.CategoryId != 0)
                url += $"&CategoryId={filterParams.CategoryId}";

            if (filterParams.SearchOrderBy != null)
                url += $"&SearchOrderBy={filterParams.SearchOrderBy}";

            var result = await _client.GetFromJsonAsync<ApiResult<BlogFilterResult>>(url);
            return result!.Data;
        }

        public async Task<BlogDto?> GetBlogById(long BlogId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<BlogDto?>>($"{ModuleName}/GetBlogById?BlogId={BlogId}");
            return result?.Data;
        }

        public async Task<BlogDto?> GetBlogBySlug(string Slug)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<BlogDto?>>($"{ModuleName}/GetBlogBySlug?Slug={Slug}");
            return result?.Data;
        }

        public async Task<ApiResult> IncreaseVisit(IncreaseBlogVisitCommand command)
        {
            var result = await _client.PatchAsJsonAsync($"{ModuleName}/IncreaseVisit",command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> Remove(long BlogId)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/DeleteBlog?BlogId={BlogId}");

            //return await result.Content.ReadFromJsonAsync<ApiResult>() ?? new ApiResult();
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
