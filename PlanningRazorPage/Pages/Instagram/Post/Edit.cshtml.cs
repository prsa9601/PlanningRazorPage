using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;
using PlanningRazorPage.Models.SocialMedia.Telegram.Post;
using PlanningRazorPage.Services.SocialMedia.Instagram;
using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Pages.Instagram.Post
{
    public class EditModel : BaseRazorPage
    {
        private readonly IInstagramService _service;

        public EditModel(IInstagramService service)
        {
            _service = service;
        }

        [BindProperty(SupportsGet = true)]
        public long PostId { get; set; }

        [BindProperty]
        public long InstagramId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "زمان انتشار الزامی است")]
        public DateTime DateOfPosting { get; set; }

        [BindProperty]
        [Url(ErrorMessage = "فرمت لینک نامعتبر است")]
        public string Link { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "توضیحات پست الزامی است")]
        [StringLength(2200, ErrorMessage = "حداکثر 2200 کاراکتر مجاز است")]
        public string Description { get; set; }

        //[BindProperty]
        //public List<IFormFile> NewImages { get; set; }

        [BindProperty]
        public List<IFormFile> Videos { get; set; }
        [BindProperty]
        public List<string> ExistingMedia { get; set; }

        //[BindProperty]
        //public string ExistingMedia { get; set; }



        [BindProperty(SupportsGet = true)]
        public List<InstagramAccountDto> Accounts { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public InstagramAccountPostDto Post { get; set; }

        public async Task<IActionResult> OnGet(long postId, long instagramId)
        {
            PostId = postId;
            Accounts = await _service.GetList();

            var instagtram = Accounts.FirstOrDefault(i => i.Id == instagramId);
            var Post = instagtram.Posts.FirstOrDefault(i => i.Id == postId);

            //var post = await _service.GetPostById(postId);
            if (Post == null) return RedirectToPage("NotFound");

            // مقداردهی فیلدها از دیتابیس
            instagramId = instagramId;
            DateOfPosting = Post.DateOfPosting;
            Link = Post.Link;
            Description = Post.Description;
            //ExistingMedia = Post.Videos;
            //IsScheduled = Post.IsScheduled;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Accounts = await _service.GetList();
                return Page();
            }

            var result = await _service.EditPost(new Models.SocialMedia.Instagram.Post.EditPostInstagramCommand
            {
                postId = PostId,
                InstagramAccountId = InstagramId,
                DateOfPosting = DateOfPosting,
                Link = Link,
                Description = Description,
                //Images = NewImages,
                Videos = Videos,
                //ExistingMedia = ExistingMedia,
                //IsScheduled = IsScheduled
            });
            //Accounts = await _service.GetList();

            return new JsonResult(new
            {
                success = true,
                instagramId = InstagramId
            });
        }

        //public async Task<IActionResult> OnPostRemoveMedia(string mediaPath)
        //{
        //    var result = await _service.RemoveMedia(PostId, mediaPath);
        //    return new JsonResult(result);
        //}
    }
}