using Microsoft.AspNetCore.Mvc;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;
using PlanningRazorPage.Models.SocialMedia.Instagram.Story;
using PlanningRazorPage.Services.SocialMedia.Instagram;

namespace PlanningRazorPage.Pages.Instagram.Story
{
    public class EditModel : BaseRazorPage
    {
        private readonly IInstagramService _service;

        public EditModel(IInstagramService service)
        {
            _service = service;
        }

        [BindProperty(SupportsGet = true)]
        public List<InstagramAccountDto>? Account { get; set; }
        [BindProperty]
        public DateTime dateOfPosting { get; set; }
        [BindProperty]
        public string link { get; set; }
        [BindProperty]
        public long InstagramId { get; set; }
        [BindProperty]
        public IFormFile? PreviousVideo { get; set; }
        [BindProperty]
        public long StoryId { get; set; }
        [BindProperty(SupportsGet = true)]
        public InstagramAccountStoryDto? Story { get; set; }
        public async Task<IActionResult> OnGet(long storyId, long instagramId)
        {
            InstagramId = instagramId;
            StoryId = storyId;
            Account = await _service.GetList();
            var instagram = Account.FirstOrDefault(i => i.Id.Equals(instagramId));
            Story = instagram.Stories.FirstOrDefault(i => i.Id.Equals(storyId));
            //Story = await _service.GetById(StoryId);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    Account = await _service.GetList();
                    return Page();
                }

                if (PreviousVideo == null || PreviousVideo.Length == 0)
                {
                    ModelState.AddModelError("Video", "لطفا یک فایل انتخاب کنید");
                    Account = await _service.GetList();
                    return Page();
                }

                // اعتبارسنجی اندازه فایل
                if (PreviousVideo.Length > 52428800) // 50MB
                {
                    ModelState.AddModelError("Video", "حجم فایل نباید بیشتر از 50 مگابایت باشد");
                    Account = await _service.GetList();
                    return Page();
                }

                var result = await _service.EditStory(new EditStoryCommand
                {
                    StoryId = StoryId,
                    DateOfPosting = dateOfPosting,
                    Image = PreviousVideo,
                    InstagramId = InstagramId,
                    Link = link
                });

                return RedirectAndShowAlert(result, RedirectToPage("List", new { instagramId = InstagramId }));
            }
            catch (Exception ex)
            {
                // لاگ خطا
                //Logger.LogError(ex, "خطا در آپلود استوری");
                ModelState.AddModelError("", "خطای داخلی سرور");
                Account = await _service.GetList();
                return Page();
            }
        }
    }
}
