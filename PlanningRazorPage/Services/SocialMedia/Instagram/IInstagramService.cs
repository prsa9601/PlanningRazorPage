using PlanningRazorPage.Models;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;
using PlanningRazorPage.Models.SocialMedia.Instagram.Post;
using PlanningRazorPage.Models.SocialMedia.Instagram.Story;
using static System.Net.Mime.MediaTypeNames;
using SendToInstagramCommand = PlanningRazorPage.Models.SocialMedia.Instagram.Post.SendToInstagramCommand;

namespace PlanningRazorPage.Services.SocialMedia.Instagram
{
    public interface IInstagramService
    {
        Task<ApiResult> DeleteStory(DeleteStoryCommand command);
        Task<ApiResult> UploadStory(SendToInstagramCommand command);
        Task<ApiResult> AddStory(AddStoryCommand command);
        Task<ApiResult> EditStory(EditStoryCommand command);
        Task<ApiResult> DeletePost(DeletePostInstagramCommand command);
        Task<ApiResult> SetImage(SetImageCommand command);
        Task<ApiResult> AddImage(AddImageCommand command);
        Task<ApiResult> RemoveImage(RemoveImagePostCommand command);
        Task<ApiResult> AddPost(AddPostInstagramCommand command);
        Task<ApiResult> EditPost(EditPostInstagramCommand command);

        //Instagram
        Task<ApiResult> PostToInstagram(SendToInstagramCommand command);


        #region Account
        Task<ApiResult> AddAccount(AddInstagramAccountCommandViewModel command);
        Task<ApiResult> EditProfile(EditInstagramAccountCommand command);
        Task<ApiResult> DeleteProfile(DeleteInstagramAccountCommand command);
        Task<ApiResult> SetProfile(SetProfileInstagramAccountCommand command);

        Task<InstagramAccountDto?> GetById(long Id);
        Task<InstagramAccountFilterResult> GetFilter(InstagramAccountFilterParam param);
        Task<List<InstagramAccountDto>?> GetList();

        #endregion
    }
}
