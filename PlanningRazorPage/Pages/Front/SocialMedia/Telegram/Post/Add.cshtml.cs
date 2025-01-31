using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Gateway.Telegram;

namespace PlanningRazorPage.Pages.Front.SocialMedia.Telegram.Post
{
    public class AddModel : PageModel
    {
        private readonly ITelegramService _service;

        public AddModel(ITelegramService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _service.AddPost();
            return Page();
        }
    }
}
