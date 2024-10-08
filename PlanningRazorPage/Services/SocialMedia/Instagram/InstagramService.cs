using PlanningRazorPage.Models;
using PlanningRazorPage.Models.SocialMedia.Instagram.Post;
using PlanningRazorPage.Models.SocialMedia.Instagram.Story;
using SendToInstagramCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.SendToInstagramCommand;

namespace PlanningRazorPage.Services.SocialMedia.Instagram
{
    public class InstagramService : IInstagramService
    {
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

        public Task<ApiResult> Add(AddPostInstagramCommand instagramCommand)
        {
            throw new NotImplementedException();
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
