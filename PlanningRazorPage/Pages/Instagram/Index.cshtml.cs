using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;
using PlanningRazorPage.Services.SocialMedia.Instagram;

namespace PlanningRazorPage.Pages.Instagram
{
    public class IndexModel : BaseRazorPage
    {
        private readonly IInstagramService _service;

        public IndexModel(IInstagramService service)
        {
            _service = service;
        }
        [BindProperty(SupportsGet = true)]
        public List<InstagramAccountDto>? InstagramDtos { get; set; }
        [BindProperty]
        public string AccessToken { get; set; }
        [BindProperty]
        public IFormFile ProfileImage { get; set; }
        [BindProperty]
        public string UserName { get; set; }

        public async Task<IActionResult> OnGet()
        {
            InstagramDtos = await _service.GetList();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // ????? ???? ????
            if (ProfileImage == null || ProfileImage.Length == 0)
            {
                ModelState.AddModelError("ProfileImage", "???? ????? ??????? ?? ?????? ????");
                return Page();
            }

            var model = new AddInstagramAccountCommandViewModel
            {
                accessToken = AccessToken,
                InstagramUserName = UserName,
                Profile = ProfileImage
            };

            var result = await _service.AddAccount(model);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.MetaData.Message);
                return Page();
            }

            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnPostDeleteAccount(long accountId)
        {
            var result = await _service.DeleteProfile(new DeleteInstagramAccountCommand
            {
                Id = accountId
            });
            if (result.IsSuccess)
                result.IsReload = true;
            return new JsonResult(JsonConvert.SerializeObject(result));
        }
    }
}
