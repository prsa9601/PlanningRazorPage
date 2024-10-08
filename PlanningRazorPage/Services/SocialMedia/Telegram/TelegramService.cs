using PlanningRazorPage.Models;
using PlanningRazorPage.Models.SocialMedia.Instagram.Post;
using PlanningRazorPage.Models.SocialMedia.Telegram.Post;
using AddImageCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.AddImageCommand;
using DeletePostCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.DeletePostCommand;
using RemoveImagePostCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.RemoveImagePostCommand;
using SetImageCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.SetImageCommand;

namespace PlanningRazorPage.Services.SocialMedia.Telegram
{
    public class TelegramService : ITelegramService
    {
        public Task<ApiResult> Delete(DeletePostCommand command)
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

        public Task<ApiResult> Add(AddPostCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> Edit(EditPostCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> PostToInstagram(SendToInstagramCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> SendMessageToTelegram(SendMessageToTelegramCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> SendImageToTelegram(SendImageToTelegramCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> SendVideoToTelegram(SendVideoToTelegramCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
