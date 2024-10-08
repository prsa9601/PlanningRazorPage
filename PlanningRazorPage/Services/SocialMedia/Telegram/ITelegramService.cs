using PlanningRazorPage.Models;
using PlanningRazorPage.Models.SocialMedia.Instagram.Post;
using PlanningRazorPage.Models.SocialMedia.Telegram.Post;
using AddImageCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.AddImageCommand;
using DeletePostCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.DeletePostCommand;
using RemoveImagePostCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.RemoveImagePostCommand;
using SetImageCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.SetImageCommand;

namespace PlanningRazorPage.Services.SocialMedia.Telegram
{
    public interface ITelegramService
    {
        Task<ApiResult> Delete(DeletePostCommand command);
        Task<ApiResult> SetImage(SetImageCommand command);
        Task<ApiResult> AddImage(AddImageCommand image);
        Task<ApiResult> RemoveImage(RemoveImagePostCommand id);
        Task<ApiResult> Add(AddPostCommand command);
        Task<ApiResult> Edit(EditPostCommand command);

        //Instagram
        Task<ApiResult> PostToInstagram(SendToInstagramCommand command);

        //Telegram
        // Task<OperationResult> DeleteTelegram(int postId);
        Task<ApiResult> SendMessageToTelegram(SendMessageToTelegramCommand command);
        Task<ApiResult> SendImageToTelegram(SendImageToTelegramCommand command);
        Task<ApiResult> SendVideoToTelegram(SendVideoToTelegramCommand command);

    }
}
