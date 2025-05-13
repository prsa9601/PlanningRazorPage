using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;
using PlanningRazorPage.Models.SocialMedia.Instagram.Story;
using PlanningRazorPage.Services.SocialMedia.Instagram;

namespace PlanningRazorPage.Pages.Instagram.Story
{
    public class AddModel : BaseRazorPage
    {
        private readonly IInstagramService _service;

        public AddModel(IInstagramService service)
        {
            _service = service;
        }
        //public class InstagramAccount
        //{
        //    public string UserName { get; set; }
        //    public long Id { get; set; }
        //}
        [BindProperty(SupportsGet = true)]
        public List<InstagramAccountDto>? Account { get; set; }
        [BindProperty]
        public DateTime dateOfPosting { get; set; }
        [BindProperty]
        public string link { get; set; }
        [BindProperty]
        public long InstagramId { get; set; }
        [BindProperty]
        public IFormFile Video { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Account = await _service.GetList();
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

                if (Video == null || Video.Length == 0)
                {
                    ModelState.AddModelError("Video", "لطفا یک فایل انتخاب کنید");
                    Account = await _service.GetList();
                    return Page();
                }

                // اعتبارسنجی اندازه فایل
                if (Video.Length > 52428800) // 50MB
                {
                    ModelState.AddModelError("Video", "حجم فایل نباید بیشتر از 50 مگابایت باشد");
                    Account = await _service.GetList();
                    return Page();
                }

                var result = await _service.AddStory(new AddStoryCommand
                {
                    DateOfPosting = dateOfPosting,
                    Image = Video,
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
