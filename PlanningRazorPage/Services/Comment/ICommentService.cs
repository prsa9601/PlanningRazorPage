using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Comment;
using System.ComponentModel.Design;

namespace PlanningRazorPage.Services.Comment
{
    public interface ICommentService
    {
        Task<ApiResult?> Create(CreateCommentCommand command);
        Task<ApiResult?> Edit(EditCommentCommand command);
        Task<ApiResult?> Delete(long CommentId);
        Task<ApiResult?> ChangeStatus(ChangeStatusCommentCommand command);
        Task<CommentDto?> GetById(long CommentId);
        Task<CommentFilterResult?> GetByFilter(CommentFilterParam filterParams);
    }
    internal class CommentService : ICommentService
    {
        private readonly HttpClient _client;

        private const string ModuleName = "Comment";
        public CommentService(HttpClient client)
        {
            _client = client;
        }


        public async Task<ApiResult?> ChangeStatus(ChangeStatusCommentCommand command)
        {
            var result = await _client.PatchAsJsonAsync($"{ModuleName}/ChangeCommentStatus", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> Create(CreateCommentCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/CreateComment", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> Delete(long CommentId)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/DeleteComment?CommentId={CommentId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> Edit(EditCommentCommand command)
        {
            var result = await _client.PutAsJsonAsync($"{ModuleName}/EditComment", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<CommentFilterResult?> GetByFilter(CommentFilterParam filterParams)
        {
            var url = $"{ModuleName}?pageId={filterParams.PageId}&take={filterParams.Take}";

            if (filterParams.UserId != null)
                url += $"userId={filterParams.UserId}";

            if (filterParams.CommentStatus != null)
                url += $"commentStatus={filterParams.CommentStatus}";

            if (filterParams.OrderBy != null)
                url += $"&orderBy={filterParams.OrderBy}";

            if (filterParams.StartDate != null)
                url += $"&StartDate{filterParams.StartDate}";

            if (filterParams.EndDate != null)
                url += $"&EndDate{filterParams.EndDate}";

            if (filterParams.BlogId != null)
                url += $"&BlogId={filterParams.BlogId}";

            var result = await _client.GetFromJsonAsync<ApiResult<CommentFilterResult>>(url);
            return result?.Data;
        }

        public async Task<CommentDto?> GetById(long CommentId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<CommentDto?>>($"{ModuleName}/GetCommentById?CommentId={CommentId}");
            return result?.Data;
        }
    }
}
