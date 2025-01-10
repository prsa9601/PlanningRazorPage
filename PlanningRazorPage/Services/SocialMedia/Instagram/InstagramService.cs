using System.Runtime.InteropServices.JavaScript;
using PlanningRazorPage.Models;
using PlanningRazorPage.Models.SocialMedia.Instagram.Post;
using PlanningRazorPage.Models.SocialMedia.Instagram.Story;
using SendToInstagramCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.SendToInstagramCommand;

namespace PlanningRazorPage.Services.SocialMedia.Instagram
{
    public class InstagramService : IInstagramService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _accessor;
        private const string ModuleName = "Instagram";

        public InstagramService(HttpClient client, IHttpContextAccessor accessor)
        {
            _client = client;
            _accessor = accessor;
        }

        public Task<ApiResult> Delete(DeleteStoryCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> UploadStory(SendToInstagramCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> EditStory(EditStoryCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> DeleteStory(DeleteStoryCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> Delete(DeletePostInstagramCommand instagramCommand)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> SetImage(SetImageCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> AddImage(AddImageCommand image)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> RemoveImage(RemoveImagePostCommand id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult> Add(AddPostInstagramCommand command)
        { 
            string dateOfPostingString = command.DateOfPosting.ToString("yyyy-MM-dd HH:mm:ss");
             

            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(dateOfPostingString), "PhoneNumber");

            if (command.ImageName != null)
                formData.Add(new StreamContent(command.ImageName.OpenReadStream()), "ImageName", command.ImageName.FileName);

            if (command.VideoName != null)
                formData.Add(new StreamContent(command.ImageName.OpenReadStream()), "VideoName", command.VideoName.FileName);

            formData.Add(new StringContent(command.Description.ToString()), "Description");
            formData.Add(new StringContent(command.Link), "Link");
            formData.Add(new StringContent(command.InstagramId), "Family");

            var result = await _client.PutAsync($"{ModuleName}", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public Task<ApiResult> Edit(EditPostInstagramCommand instagramCommand)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> PostToInstagram(SendToInstagramCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
