using PlanningRazorPage.Models;
using PlanningRazorPage.Models.SocialMedia.Telegram.Post;
using PlanningRazorPage.Models.SocialMedia.Telegram;
using AddImageCommand = PlanningRazorPage.Models.SocialMedia.Telegram.Post.AddImageCommand;
using DeletePostCommand = PlanningRazorPage.Models.SocialMedia.Telegram.Post.DeletePostCommand;
using RemoveImagePostCommand = PlanningRazorPage.Models.SocialMedia.Telegram.Post.RemoveImagePostCommand;
using SetImageCommand = PlanningRazorPage.Models.SocialMedia.Telegram.Post.SetImageCommand;
using Newtonsoft.Json;
using System.Text;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Models.Blog;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;

namespace PlanningRazorPage.Services.SocialMedia.Telegram
{
    public class TelegramService : ITelegramService
    {
        private readonly HttpClient _client;

        private const string ModuleName = "Telegram";
        public TelegramService(HttpClient client)
        {
            _client = client;
        }

        //private readonly IHttpContextAccessor _accessor;

        public async Task<ApiResult> Delete(DeletePostCommand command)
        {
            var result = await _client.DeleteAsync(
                $"{ModuleName}/DeletePost?PostId={command.PostId}&&TelegramId={command.TelegramId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> SetImage(SetImageCommand command)
        {
            var formData = new MultipartFormDataContent();

            // اضافه کردن لیست ویدیوها (Videos)

            formData.Add(new StringContent(command.postId.ToString()),
                "postId");

            formData.Add(new StringContent(command.TelegramId.ToString()),
                "TelegramId");

            if (command.Images != null && command.Images.Count > 0)
            {
                for (int i = 0; i < command.Images.Count; i++)
                {
                    var image = command.Images[i];

                    // اضافه کردن فایل تصویر
                    formData.Add(
                        content: new StreamContent(image.File.OpenReadStream()),
                        name: $"Images[{i}].File", // باید با نام مدل سمت سرور مطابقت داشته باشد
                        fileName: image.File.FileName
                    );

                    // اضافه کردن سکانس
                    formData.Add(
                        content: new StringContent(image.Sequence.ToString()),
                        name: $"Images[{i}].Sequence"
                    );
                }

            }
                var result = await _client.PatchAsync($"{ModuleName}/AddImagePost", formData);
                return await result.Content.ReadFromJsonAsync<ApiResult>();

        }

        public async Task<ApiResult> AddImage(AddImageCommand image)
        {
            var formData = new MultipartFormDataContent();

            // اضافه کردن لیست ویدیوها (Videos)

            formData.Add(new StreamContent(image.ImageFile.OpenReadStream()),
                "ImageFile", image.ImageFile.FileName);

            formData.Add(new StringContent(image.ProductId.ToString()),
                "ProductId");
            formData.Add(new StringContent(image.Sequence.ToString()),
                "Sequence");
            formData.Add(new StringContent(image.TelegramId.ToString()),
                "TelegramId");

            var result = await _client.PatchAsync($"{ModuleName}/AddImagePost", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public Task<ApiResult> RemoveImage(RemoveImagePostCommand id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult> Add(AddPostCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.TelegramId.ToString()), "TelegramId");
            formData.Add(new StringContent(command.dateOfPosting.ToString("o")),
                "dateOfPosting");
            formData.Add(new StringContent(command.description), "description");
            formData.Add(new StringContent(command.link ?? string.Empty), "link");
            formData.Add(new StringContent(command.slug), "slug");
            // اضافه کردن لیست تصاویر (Images)
            if (command.Images != null && command.Images.Count > 0)
            {
                for (int i = 0; i < command.Images.Count; i++)
                {
                    var image = command.Images[i];
                    var streamContent = new StreamContent(image.OpenReadStream());
                    formData.Add(streamContent, $"Images[{i}]", image.FileName);
                }
            }
            // اضافه کردن لیست ویدیوها (Videos)
            if (command.Videos != null && command.Videos.Count > 0)
            {
                for (int i = 0; i < command.Videos.Count; i++)
                {
                    var video = command.Videos[i];
                    var streamContent = new StreamContent(video.OpenReadStream());
                    formData.Add(streamContent, $"Videos[{i}]", video.FileName);
                }
            }

            var result = await _client.PostAsync($"{ModuleName}/AddPost", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> Edit(EditPostCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.TelegramId.ToString()), "TelegramId");
            formData.Add(new StringContent(command.DateOfPosting.ToString("o")),
                "DateOfPosting");
            formData.Add(new StringContent(command.Description), "Description");
            //formData.Add(new StringContent(command.li ?? string.Empty), "Link");
            formData.Add(new StringContent(command.Slug), "Slug");
            // اضافه کردن لیست تصاویر (Images)
            if (command.Images != null && command.Images.Count > 0)
            {
                for (int i = 0; i < command.Images.Count; i++)
                {
                    var image = command.Images[i];
                    var streamContent = new StreamContent(image.OpenReadStream());
                    formData.Add(streamContent, $"Images[{i}]", image.FileName);
                }
            }
            // اضافه کردن لیست ویدیوها (Videos)
            if (command.Videos != null && command.Videos.Count > 0)
            {
                for (int i = 0; i < command.Videos.Count; i++)
                {
                    var video = command.Videos[i];
                    var streamContent = new StreamContent(video.OpenReadStream());
                    formData.Add(streamContent, $"Videos[{i}]", video.FileName);
                }
            }

            var result = await _client.PatchAsync($"{ModuleName}/EditPost", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        //public Task<ApiResult> PostToInstagram(SendToInstagramCommand command)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ApiResult> SendMessageToTelegram(SendMessageToTelegramCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/SendMessage", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> SendImageToTelegram(SendImageToTelegramCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/SendImage", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> SendVideoToTelegram(SendVideoToTelegramCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/SendVideo", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> RemoveAccount(DeleteInstagramAccountCommand command)
        {
            var result = await _client.DeleteAsync(
                $"{ModuleName}/DeleteAccount?Id={command.Id}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> AddAccount(CreateTelegramAccountCommandViewModel command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/CreateAccount", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditAccount(EditTelegramAccountCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/EditAccount", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
        public async Task<ApiResult> DeleteAccount(RemoveTelegramAccountCommand command)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/RemoveAccount?TelegramId={command.TelegramId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
        //    public async Task<ApiResult> EditAccount(EditPostCommand command)
        //{
        //    var formData = new MultipartFormDataContent();
        //    formData.Add(new StringContent(command.TelegramId.ToString()), "TelegramId");
        //    formData.Add(new StringContent(command.PostId.ToString()), "PostId");
        //    formData.Add(new StringContent(command.DateOfPosting.ToString("o")),
        //        "DateOfPosting");
        //    formData.Add(new StringContent(command.Description), "Description");
        //    //formData.Add(new StringContent(command.li ?? string.Empty), "Link");
        //    formData.Add(new StringContent(command.Slug), "Slug");
        //    // اضافه کردن لیست تصاویر (Images)
        //    if (command.Images != null && command.Images.Count > 0)
        //    {
        //        for (int i = 0; i < command.Images.Count; i++)
        //        {
        //            var image = command.Images[i];
        //            var streamContent = new StreamContent(image.OpenReadStream());
        //            formData.Add(streamContent, $"Images[{i}]", image.FileName);
        //        }
        //    }
        //    // اضافه کردن لیست ویدیوها (Videos)
        //    if (command.Videos != null && command.Videos.Count > 0)
        //    {
        //        for (int i = 0; i < command.Videos.Count; i++)
        //        {
        //            var video = command.Videos[i];
        //            var streamContent = new StreamContent(video.OpenReadStream());
        //            formData.Add(streamContent, $"Videos[{i}]", video.FileName);
        //        }
        //    }

        //    var result = await _client.PatchAsync($"{ModuleName}/EditAccount", formData);
        //    return await result.Content.ReadFromJsonAsync<ApiResult>();
        //}

        public async Task<TelegramAccountDto?> GetTelegramAccountById(long TelegramAccountId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<TelegramAccountDto?>>($"{ModuleName}/GetTelegramAccountById");
            return result?.Data!;
        }

        public async Task<List<TelegramAccountDto>?> GetListTelegramAccount()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<TelegramAccountDto?>>>($"{ModuleName}/GetListTelegramAccount");
            return result?.Data!;
        }

        public async Task<TelegramAccountFilterResult?> GetTelegramAccountByFilter(TelegramAccountFilterParam param)
        {
            var url = $"{ModuleName}?PageId={param.PageId}&Take={param.Take}";

            if (param.UserName!= null)
                url += $"&UserName={param.UserName}";

            if (param.TelegramAccountId != null)
                url += $"&TelegramAccountId={param.TelegramAccountId}";

            if (param.Chat_Id != null)
                url += $"&Chat_Id={param.Chat_Id}";

            if (param.PageId != null && param.PageId > 0)
                url += $"&PageId={param.PageId}";

            if (param.SearchOrderBy != null)
                url += $"&SearchOrderBy={param.SearchOrderBy}";

            var result = await _client.GetFromJsonAsync<ApiResult<TelegramAccountFilterResult>>(url);
            return result?.Data;
        }
    }
}
