using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;
using PlanningRazorPage.Services.SocialMedia.Instagram;

namespace PlanningRazorPage.Page.Telegram.Post
{
    public class ListModel : PageModel
    {
        private readonly IInstagramService _service;

        public ListModel(IInstagramService service)
        {
            _service = service;
        }
        [BindProperty(SupportsGet = true)]
        public List<InstagramAccountPostDto> PostDTOs { get; set; }
        public async void OnGet(string accountId)
        {
            var result = await _service.GetFilter(new Models.SocialMedia.Instagram.Account.InstagramAccountFilterParamViewModel
            {
                InstagramUserName = "accountId"
            });
            var instagram = result.Data.FirstOrDefault(s => s.InstagramId.Equals(accountId));
            PostDTOs = instagram.Posts;    
        }
    }
}
