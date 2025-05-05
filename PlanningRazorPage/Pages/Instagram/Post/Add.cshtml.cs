using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.FileUtil;
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
        public long InstagramAccountId { get; set; }

        [Required(ErrorMessage = "زمان انتشار الزامی است")]
        public DateTime DateOfPosting { get; set; }

        [Url(ErrorMessage = "فرمت لینک نامعتبر است")]
        public string Link { get; set; } = string.Empty;

        [Required(ErrorMessage = "توضیحات پست الزامی است")]
        [StringLength(2200, ErrorMessage = "حداکثر 2200 کاراکتر مجاز است")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "حداقل یک عکس الزامی است")]
        [MaxFileCount(10, ErrorMessage = "حداکثر 10 عکس مجاز است")]
        [AllowedFileExtensions(new[] { ".jpg", ".jpeg", ".png" })]
        public List<IFormFile>? Images { get; set; }

        [MaxFileCount(3, ErrorMessage = "حداکثر 3 ویدیو مجاز است")]
        [AllowedFileExtensions(new[] { ".mp4", ".mov", ".mkv" })]
        public List<IFormFile>? Videos { get; set; }
        public void OnGet(long accountId)
        {
        }
        public async Task<IActionResult> OnPost()
        {

            var result = await _service.AddPost(new Models.SocialMedia.Instagram.Post.AddPostInstagramCommand
            {
                Images = Images,
                DateOfPosting = DateOfPosting,
                Description = Description,
                InstagramAccountId = InstagramAccountId,
                Link = Link,
                Videos = Videos
            });
            return Page();

        }
    }
}
