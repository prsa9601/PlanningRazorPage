using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.SocialMedia.Instagram.Account;
using PlanningRazorPage.Models.SocialMedia.Telegram;
using PlanningRazorPage.Services.SocialMedia.Telegram;
using System.Diagnostics;
using Telegram.Bot.Types;

namespace PlanningRazorPage.Pages.Telegram
{
    public class IndexModel : BaseRazorPage
    {
        private readonly ITelegramService _service;

        public IndexModel(ITelegramService service)
        {
            _service = service;
        }
        [BindProperty(SupportsGet = true)]
        public List<TelegramAccountDto>? TelegramDTOs { get; set; }
        //[BindProperty]
        //public string UserName { get; set; }
        //[BindProperty]
        //public string AccessToken { get; set; }
        [BindProperty]
        public string? Token { get; set; }
        [BindProperty]
        public string Chat_Id { get; set; }
        [BindProperty]
        public bool UsedDefaultToken { get; set; }
        //[BindProperty]
        //public IFormFile ProfileImage { get; set; }
        public async Task<IActionResult> OnGet()
        {
            TelegramDTOs = await _service.GetListTelegramAccount();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _service.AddAccount(new Models.SocialMedia.Telegram.Post
                .CreateTelegramAccountCommandViewModel(Token, Chat_Id, UsedDefaultToken));
            return RedirectAndShowAlert(result! ,RedirectToPage("Index"));
        }
        public async Task<IActionResult> OnPostDelete(long accountId)
        {
            var result = await _service.DeleteAccount(new Models.SocialMedia.Telegram.
                Post.RemoveTelegramAccountCommand(accountId));
            if (result.IsSuccess)
                result.IsReload = true;
            return new JsonResult(JsonConvert.SerializeObject(result));
        }

    }
}
