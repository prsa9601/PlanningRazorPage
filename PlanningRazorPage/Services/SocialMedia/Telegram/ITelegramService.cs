using PlanningRazorPage.Models;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;
using PlanningRazorPage.Models.SocialMedia.Telegram;
using PlanningRazorPage.Models.SocialMedia.Telegram.Post;
using AddImageCommand = PlanningRazorPage.Models.SocialMedia.Telegram.Post.AddImageCommand;
using DeletePostCommand = PlanningRazorPage.Models.SocialMedia.Telegram.Post.DeletePostCommand;
using RemoveImagePostCommand = PlanningRazorPage.Models.SocialMedia.Telegram.Post.RemoveImagePostCommand;
using SetImageCommand = PlanningRazorPage.Models.SocialMedia.Telegram.Post.SetImageCommand;

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
        Task<ApiResult> RemoveAccount(DeleteInstagramAccountCommand id);
        Task<ApiResult?> AddAccount(CreateTelegramAccountCommandViewModel command);
        Task<ApiResult> EditAccount(EditTelegramAccountCommand command);
        Task<ApiResult> DeleteAccount(RemoveTelegramAccountCommand command);

        //Instagram
        //Task<ApiResult> PostToInstagram(SendToInstagramCommand command);

        //Telegram
        // Task<OperationResult> DeleteTelegram(int postId);
        Task<ApiResult> SendMessageToTelegram(SendMessageToTelegramCommand command);
        Task<ApiResult> SendImageToTelegram(SendImageToTelegramCommand command);
        Task<ApiResult> SendVideoToTelegram(SendVideoToTelegramCommand command);

        Task<TelegramAccountDto?> GetTelegramAccountById(long TelegramAccountId);
        Task<List<TelegramAccountDto>?> GetListTelegramAccount();
        Task<TelegramAccountFilterResult?> GetTelegramAccountByFilter(TelegramAccountFilterParam param);

    }
}
