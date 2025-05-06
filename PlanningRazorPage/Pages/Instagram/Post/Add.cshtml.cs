using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.FileUtil;
using PlanningRazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using PlanningRazorPage.Services.SocialMedia.Instagram;
using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Pages.Instagram.Post
{
    public class AddModel : PageModel
    {
        private readonly IInstagramService _service;

        public AddModel(IInstagramService service)
        {
            _service = service;
        }
        [BindProperty]
        public long InstagramAccountId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "زمان انتشار الزامی است")]
        public DateTime DateOfPosting { get; set; } = DateTime.UtcNow.AddHours(3.5);

        [BindProperty]
        [Url(ErrorMessage = "فرمت لینک نامعتبر است")]
        public string Link { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "توضیحات پست الزامی است")]
        [StringLength(2200, ErrorMessage = "حداکثر 2200 کاراکتر مجاز است")]
        public string Description { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "حداقل یک عکس الزامی است")]
        [MaxFileCount(10, ErrorMessage = "حداکثر 10 عکس مجاز است")]
        [AllowedFileExtensions(new[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(5 * 1024 * 1024, ErrorMessage = "حجم هر عکس باید کمتر از ۵ مگابایت باشد")]
        public List<IFormFile> Images { get; set; }

        [BindProperty]
        [MaxFileCount(3, ErrorMessage = "حداکثر 3 ویدیو مجاز است")]
        [AllowedFileExtensions(new[] { ".mp4", ".mov", "mkv" })]
        [MaxFileSize(50 * 1024 * 1024, ErrorMessage = "حجم هر ویدیو باید کمتر از ۵۰ مگابایت باشد")]
        public List<IFormFile> Videos { get; set; }

     
        public void OnGet(long accountId)
        {
            InstagramAccountId = accountId;
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _service.AddPost(new Models.SocialMedia.Instagram.Post.AddPostInstagramCommand
            {
                Images = Images,
                Videos = Videos,
                DateOfPosting = DateOfPosting,
                Description = Description,
                InstagramAccountId = InstagramAccountId,
                Link = Link
            });

            if (result.IsSuccess)
            {
                return RedirectToPage("../Index"/*, new { accountId = InstagramAccountId }*/);
            }

            ModelState.AddModelError(string.Empty, result.MetaData.Message);
            return Page();

        }
    }
}
