using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PlanningRazorPage.Models;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;
using PlanningRazorPage.Models.SocialMedia.Instagram.Post;
using PlanningRazorPage.Models.SocialMedia.Instagram.Story;
using PlanningRazorPage.Models.SocialMedia.Telegram;
using static PlanningRazorPage.Models.SocialMedia.Instagram.Post.PostFilterData;
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

        public async Task<ApiResult> DeleteStory(DeleteStoryCommand command)
        {
            var result = await _client.DeleteAsync(
                $"{ModuleName}/DeletePost?InstagramId={command.InstagramId}&StoryId={command.StoryId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> UploadStory(SendToInstagramCommand command)
        {
            var result = await _client.PostAsJsonAsync(
                  $"{ModuleName}", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
        public async Task<ApiResult> AddStory(AddStoryCommand command)
        {
            try
            {
                string dateOfPostingString = command.DateOfPosting.ToString("yyyy-MM-dd HH:mm:ss");
                // ایجاد فرم دیتا
                var formData = new MultipartFormDataContent();
                // افزودن فیلدهای متنی
                formData.Add(new StringContent(command.InstagramId.ToString()), "InstagramId");
                formData.Add(new StringContent(dateOfPostingString), "DateOfPosting");
                formData.Add(new StringContent(command.Link), "Link");

                // افزودن تصاویر (حلقه برای فایل‌های چندگانه)
                if (command.Image != null && command.Image.Length <= 52428800)
                {

                    formData.Add(
                        new StreamContent(command.Image.OpenReadStream()),
                        "Image", // نام فیلد باید دقیقا منطبق با سرور باشد
                        command.Image.FileName
                    );

                }
                var result = await _client.PostAsync($"{ModuleName}/AddStory", formData);

                return await result.Content.ReadFromJsonAsync<ApiResult>();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex);
                return new ApiResult
                {
                    IsSuccess = false,
                    IsReload = false,
                    MetaData = new MetaData
                    {
                        AppStatusCode = AppStatusCode.ServerError,
                        Message = ex.Message
                    }
                };

            }
        }

        public async Task<ApiResult> EditStory(EditStoryCommand command)
        {
            try
            {
                string dateOfPostingString = command.DateOfPosting.ToString("yyyy-MM-dd HH:mm:ss");
                // ایجاد فرم دیتا
                var formData = new MultipartFormDataContent();
                // افزودن فیلدهای متنی
                formData.Add(new StringContent(command.StoryId.ToString()), "StoryId");
                formData.Add(new StringContent(command.InstagramId.ToString()), "InstagramId");
                formData.Add(new StringContent(dateOfPostingString), "DateOfPosting");
                formData.Add(new StringContent(command.Link), "Link");

                // افزودن تصاویر (حلقه برای فایل‌های چندگانه)
                if (command.Image != null && command.Image.Length <= 52428800)
                {

                    formData.Add(
                        new StreamContent(command.Image.OpenReadStream()),
                        "Image", // نام فیلد باید دقیقا منطبق با سرور باشد
                        command.Image.FileName
                    );

                }
                var result = await _client.PatchAsync($"{ModuleName}/EditStory", formData);

                return await result.Content.ReadFromJsonAsync<ApiResult>();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex);
                return new ApiResult
                {
                    IsSuccess = false,
                    IsReload = false,
                    MetaData = new MetaData
                    {
                        AppStatusCode = AppStatusCode.ServerError,
                        Message = ex.Message
                    }
                };

            }
        }

        public async Task<ApiResult> DeletePost(DeletePostInstagramCommand command)
        {
            var result = await _client.DeleteAsync(
               $"{ModuleName}/DeletePost?InstagramId={command.InstagramId}&Id={command.Id}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> SetImage(SetImageCommand command)
        {
            var result = await _client.PostAsJsonAsync(
                $"{ModuleName}/SetImage", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> AddImage(AddImageCommand command)
        {
            var result = await _client.PostAsJsonAsync(
               $"{ModuleName}/AddImage", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> RemoveImage(RemoveImagePostCommand command)
        {
            var result = await _client.DeleteAsync(
           $"{ModuleName}/RemoveImage?ImageId=" +
           $"{command.ImageId}&&InstagramId={command.InstagramId}" +
           $"&&PostId={command.PostId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> AddPost(AddPostInstagramCommand command)
        {
            // تبدیل تاریخ به فرمت استاندارد
            string dateOfPostingString = command.DateOfPosting.ToString("yyyy-MM-dd HH:mm:ss");
            // ایجاد فرم دیتا
            var formData = new MultipartFormDataContent();
            // افزودن فیلدهای متنی
            formData.Add(new StringContent(command.InstagramAccountId.ToString()), "InstagramAccountId");
            formData.Add(new StringContent(dateOfPostingString), "DateOfPosting");
            formData.Add(new StringContent(command.Description), "Description");
            formData.Add(new StringContent(command.Link), "Link");

            // افزودن تصاویر (حلقه برای فایل‌های چندگانه)
            //if (command.Images != null && command.Images.Any())
            //{
            //    foreach (var image in command.Images)
            //    {
            //        formData.Add(
            //            new StreamContent(image.OpenReadStream()),
            //            "Images", // نام فیلد باید دقیقا منطبق با سرور باشد
            //            image.FileName
            //        );
            //    }
            //}
            // افزودن ویدیوها (حلقه برای فایل‌های چندگانه)
            //if (command.Videos != null && command.Videos.Any())
            //{
            //    foreach (var video in command.Videos)
            //    {
            //        formData.Add(
            //            new StreamContent(video.OpenReadStream()),
            //            "Videos", // نام فیلد باید دقیقا منطبق با سرور باشد
            //            video.FileName
            //        );
            //    }
            //}
            if (command.Videos != null && command.Videos.Any())
            {
                foreach (var video in command.Videos)
                {
                    // بدون using
                    var stream = video.OpenReadStream();
                    var streamContent = new StreamContent(stream);
                    formData.Add(streamContent, "Videos", video.FileName);
                }
            }
            // ارسال درخواست به آدرس صحیح
            var result = await _client.PostAsync($"{ModuleName}/AddPost", formData);

            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditPost(EditPostInstagramCommand command)
        {
            var formData = new MultipartFormDataContent();
            // افزودن فیلدهای متنی
            formData.Add(new StringContent(command.postId.ToString()), "postId");
            formData.Add(new StringContent(command.InstagramAccountId.ToString()), "InstagramAccountId");
            formData.Add(new StringContent(command.DateOfPosting.ToString("yyyy-MM-dd HH:mm:ss")), "DateOfPosting");
            formData.Add(new StringContent(command.Description), "Description");
            formData.Add(new StringContent(command.Link), "Link");
            // افزودن تصاویر جدید (حلقه برای فایلهای چندگانه)
            //if (command.Images != null && command.Images.Any())
            //{
            //    foreach (var image in command.Images)
            //    {
            //        formData.Add(
            //            new StreamContent(image.OpenReadStream()),
            //            "Images", // نام فیلد منطبق با سرور
            //            image.FileName
            //        );
            //    }
            //}
            // افزودن ویدیوهای جدید (حلقه برای فایلهای چندگانه)
            if (command.Videos != null && command.Videos.Any())
            {
                foreach (var video in command.Videos)
                {
                    formData.Add(
                        new StreamContent(video.OpenReadStream()),
                        "Videos", // نام فیلد منطبق با سرور
                        video.FileName
                    );
                }
            }
            // ارسال درخواست به آدرس صحیح
            var result = await _client.PatchAsync($"{ModuleName}/EditPost", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> PostToInstagram(SendToInstagramCommand command)
        {
            var result = await _client.PostAsJsonAsync(
              $"{ModuleName}/SetImage", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        #region Account 

        public async Task<ApiResult> AddAccount(AddInstagramAccountCommandViewModel command)
        {
            var formData = new MultipartFormDataContent();

            formData.Add(new StreamContent(command.Profile.OpenReadStream()), "Profile", command.Profile.FileName);

            formData.Add(new StringContent(command.InstagramUserName.ToString()), "InstagramUserName");
            formData.Add(new StringContent(command.accessToken), "accessToken");
            //formData.Add(new StringContent(command.InstagramId), "Family");

            var result = await _client.PostAsync($"{ModuleName}/AddInstagramAccount", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditProfile(EditInstagramAccountCommand command)
        {
            var formData = new MultipartFormDataContent();

            formData.Add(new StreamContent(command.Profile.OpenReadStream()), "ImageName", command.Profile.FileName);

            formData.Add(new StringContent(command.UserName.ToString()), "UserName");
            formData.Add(new StringContent(command.Id.ToString()), "Id");
            formData.Add(new StringContent(command.accessToken), "accessToken");
            //formData.Add(new StringContent(command.InstagramId), "Family");

            var result = await _client.PatchAsync($"{ModuleName}", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> DeleteProfile(DeleteInstagramAccountCommand command)
        {
            // ارسال درخواست حذف به آدرس صحیح
            var response = await _client.DeleteAsync(
                $"{ModuleName}/DeleteInstagramAccount?id={command.Id}"
            );
            return await response.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> SetProfile(SetProfileInstagramAccountCommand command)
        {
            var formData = new MultipartFormDataContent();
            // افزودن فیلد Id
            formData.Add(new StringContent(command.Id.ToString()), "Id");
            // افزودن تصویر پروفایل
            if (command.Image != null)
            {
                formData.Add(
                    new StreamContent(command.Image.OpenReadStream()),
                    "Image", // نام فیلد باید دقیقاً مطابق سرور باشد
                    command.Image.FileName
                );
            }
            // ارسال درخواست به آدرس صحیح
            var response = await _client.PatchAsync(
                $"{ModuleName}/SetProfileInstagramAccount",
                formData
            );
            return await response.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<InstagramAccountDto?> GetById(long Id)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<InstagramAccountDto?>>($"{ModuleName}/GetInstagramAccountById?Id={Id}");
            return result?.Data!;
        }

        public async Task<InstagramAccountFilterResult> GetFilter(InstagramAccountFilterParamViewModel param)
        {
            var url = $"{ModuleName}/GetInstagramByFilter?PageId={param.PageId}&Take={param.Take}";

            //if (param.UserName != null)
            //    url += $"&UserName={param.UserName}";

            if (param.SearchOrderBy != null)
                url += $"&SearchOrderBy={param.SearchOrderBy}";

            if (param.EndTime != DateTime.MaxValue || param.EndTime != null)
                url += $"&EndTime={param.EndTime}";

            if (param.StartTime != DateTime.MinValue || param.StartTime != null)
                url += $"&StartTime={param.StartTime}";

            if (param.InstagramUserName != null)
                url += $"&InstagramUserName={param.InstagramUserName}";

            var result = await _client.GetFromJsonAsync<ApiResult<InstagramAccountFilterResult>>(url);
            return result?.Data!;
        }

        public async Task<List<InstagramAccountDto>?> GetList()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<InstagramAccountDto>?>>($"{ModuleName}/GetListInstagram");
            return result?.Data!;
        }
        #endregion


        #region Post
        public async Task<InstagramPostFilterResult> GetPostByFilter(InstagramPostFilterParam param)
        {
            var url = $"{ModuleName}/GetInstagramPostByFilter?PageId={param.PageId}&Take={param.Take}";

            //if (param.UserName != null)
            //    url += $"&UserName={param.UserName}";

            if (param.SearchOrderBy != null)
                url += $"&SearchOrderBy={param.SearchOrderBy}";

            if (param.InstagramId != null)
                url += $"&InstagramId={param.InstagramId}";

            if (param.Search != null)
                url += $"&Search={param.Search}";

            var result = await _client.GetFromJsonAsync<ApiResult<InstagramPostFilterResult>>(url);
            return result?.Data!;
        }
        #endregion

        #region Story
        public async Task<StoryFilterResult> GetStoryByFilter(StoryFilterParam param)
        {
            var url = $"{ModuleName}/GetInstagramStoryByFilter?PageId={param.PageId}&Take={param.Take}";

            //if (param.UserName != null)
            //    url += $"&UserName={param.UserName}";

            if (param.SearchOrderBy != null)
                url += $"&SearchOrderBy={param.SearchOrderBy}";

            if (param.InstagramId != null)
                url += $"&InstagramId={param.InstagramId}";

            if (param.Search != null)
                url += $"&Search={param.Search}";

            var result = await _client.GetFromJsonAsync<ApiResult<StoryFilterResult>>(url);
            return result?.Data!;
        }
        #endregion
    }
}