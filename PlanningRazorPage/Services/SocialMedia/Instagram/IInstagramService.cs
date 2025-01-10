using PlanningRazorPage.Models;
using PlanningRazorPage.Models.SocialMedia.Instagram.Post;
using PlanningRazorPage.Models.SocialMedia.Instagram.Story;
using static System.Net.Mime.MediaTypeNames;
using SendToInstagramCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.SendToInstagramCommand;

namespace PlanningRazorPage.Services.SocialMedia.Instagram
{
    public interface IInstagramService
    {
        Task<ApiResult> Delete(DeleteStoryCommand command);
        //Task<OperationResult> DeleteStory();
        Task<ApiResult> UploadStory(SendToInstagramCommand command);
        Task<ApiResult> EditStory(EditStoryCommand command);
        Task<ApiResult> DeleteStory(DeleteStoryCommand command);
        Task<ApiResult> Delete(DeletePostInstagramCommand instagramCommand);
        Task<ApiResult> SetImage(SetImageCommand command);
        Task<ApiResult> AddImage(AddImageCommand image);
        Task<ApiResult> RemoveImage(RemoveImagePostCommand id);
        Task<ApiResult> Add(AddPostInstagramCommand command);
        Task<ApiResult> Edit(EditPostInstagramCommand instagramCommand);

        //Instagram
        Task<ApiResult> PostToInstagram(SendToInstagramCommand command);


    }
}
