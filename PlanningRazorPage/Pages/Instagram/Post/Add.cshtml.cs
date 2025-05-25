using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.FileUtil;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;
using PlanningRazorPage.Models.SocialMedia.Instagram.Post;
using PlanningRazorPage.Services.SocialMedia.Instagram;
using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlanningRazorPage.Pages.Instagram.Post
{
    public class AddModel : BaseRazorPage
    {
        private readonly IInstagramService _service;

        public AddModel(IInstagramService service)
        {
            _service = service;
        }
        //[BindProperty]
        //public long InstagramAccountId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "زمان انتشار الزامی است")]
        public DateTime DateOfPosting { get; set; } = DateTime.UtcNow.AddHours(3.5);

        [BindProperty]
        //[Url(ErrorMessage = "فرمت لینک نامعتبر است")]
        public string Link { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "توضیحات پست الزامی است")]
        [StringLength(2200, ErrorMessage = "حداکثر 2200 کاراکتر مجاز است")]
        public string Description { get; set; } = string.Empty;

        //[BindProperty]
        //[Required(ErrorMessage = "حداقل یک عکس الزامی است")]
        //[MaxFileCount(10, ErrorMessage = "حداکثر 10 عکس مجاز است")]
        //[AllowedFileExtensions(new[] { ".jpg", ".jpeg", ".png" })]
        //[MaxFileSize(5 * 1024 * 1024, ErrorMessage = "حجم هر عکس باید کمتر از ۵ مگابایت باشد")]
        //public List<IFormFile> Images { get; set; }

        //[BindProperty]
        //[MaxFileCount(6, ErrorMessage = "حداکثر 3 ویدیو مجاز است")]
        //[AllowedFileExtensions(new[] { ".mp4", ".mov", "mkv" })]
        //[MaxFileSize(50 * 1024 * 1024, ErrorMessage = "حجم هر ویدیو باید کمتر از ۵۰ مگابایت باشد")]

        [BindProperty]
        [Required(ErrorMessage = "حداقل یک فایل الزامی است")]
        [MaxFileCount(6, ErrorMessage = "حداکثر ۶ فایل مجاز است")]
        [AllowedFileExtensions(new[] {
    ".jpg", ".jpeg", ".png", // تصاویر
    ".mp4", ".mov", ".mkv", ".webm", ".avi", // ویدیوها
    ".gif" // GIF های متحرک
}, ErrorMessage = "فرمت فایل مجاز نیست")]
        [MaxFileSize(100 * 1024 * 1024, ErrorMessage = "حجم هر فایل باید کمتر از ۵۰ مگابایت باشد")]
        public IFormFileCollection Videos { get; set; } 
        [BindProperty(SupportsGet = true)]
        public List<InstagramAccountDto> Account { get; set; }
        [BindProperty]
        public long InstagramId { get; set; }

        public async Task<IActionResult> OnGet()
        {
            //InstagramAccountId = accountId;
            Account = await _service.GetList();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                // اعتبارسنجی مدل
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Any())
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                        );

                    return new JsonResult(new
                    {
                        success = false,
                        errorType = "validation",
                        errors
                    });
                }

                //// تبدیل تاریخ به میلادی
                //var persianDate = DateOfPosting.ToString("yyyy/MM/dd HH:mm");
                //var gregorianDate = moment(persianDate, "jYYYY/jMM/jDD HH:mm", "fa")
                //    .locale("en")
                //    .toDate();

                // پردازش داده‌ها
                var result = await _service.AddPost(new AddPostInstagramCommand
                {
                    Videos = Videos.ToList(),
                    DateOfPosting = DateOfPosting,
                    Description = Description,
                    InstagramAccountId = InstagramId,
                    Link = Link
                });

                if (!result.IsSuccess)
                {
                    return new JsonResult(new
                    {
                        success = false,
                        errorType = "server",
                        error = result.MetaData.Message
                    });
                }

                return new JsonResult(new
                {
                    success = true,
                    instagramId = InstagramId
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    success = false,
                    errorType = "exception",
                    error = ex.Message
                });
            }
        }
    }
}
//if (!ModelState.IsValid)
//{
//    var errors = ModelState
//        .Where(x => x.Value.Errors.Count > 0)
//        .ToDictionary(
//            kvp => kvp.Key,
//            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
//        );

//    return new JsonResult(new
//    {
//        success = false,
//        errorType = "validation",
//        errors
//    });
//}
//public async Task<IActionResult> OnPost()
//{
//    try
//    {
//        if (!ModelState.IsValid)
//        {
//            var errors = ModelState
//                .Where(x => x.Value.Errors.Count > 0)
//                .ToDictionary(
//                    kvp => kvp.Key,
//                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
//                );

//            return new JsonResult(new
//            {
//                success = false,
//                errorType = "validation",
//                errors
//            });
//        }

//        var result = await _service.AddPost(new AddPostInstagramCommand
//        {
//            Videos = Videos,
//            DateOfPosting = DateOfPosting,
//            Description = Description,
//            InstagramAccountId = InstagramId,
//            Link = Link
//        });

//        return new JsonResult(new
//        {
//            success = result.IsSuccess,
//            instagramId = InstagramId
//        });
//    }
//    catch (Exception ex)
//    {
//        return new JsonResult(new
//        {
//            success = false,
//            errorType = "exception",
//            error = ex.Message
//        });
//    }
//}