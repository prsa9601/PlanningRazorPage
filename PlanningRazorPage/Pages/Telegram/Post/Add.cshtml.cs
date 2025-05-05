using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.FileUtil;
using PlanningRazorPage.Services.SocialMedia.Telegram;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PlanningRazorPage.Pages.Telegram.Post
{
    public class AddModel : PageModel
    {
        private readonly ITelegramService _service;

        public AddModel(ITelegramService service)
        {
            _service = service;
        }
        //public class InputModel
        //{
        //    public long ChatId { get; set; }

        //}
        //[BindProperty]
        //public InputModel information { get; set; } = new InputModel();
        [BindProperty(SupportsGet = true)]
        public long ChatId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Description { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "حداقل یک عکس الزامی است")]
        [MaxFileCount(5, ErrorMessage = "حداکثر 5 عکس مجاز است")]
        [AllowedFileExtensions(new[] { ".jpg", ".jpeg", ".png" },
         ErrorMessage = "فرمت‌های مجاز برای عکس: jpg, png")]
        public List<IFormFile> ImageFiles { get; set; } = new();

        [BindProperty]
        [MaxFileCount(3, ErrorMessage = "حداکثر 3 ویدیو مجاز است")]
        [AllowedFileExtensions(new[] { ".mp4", ".mov", ".avi" },
            ErrorMessage = "فرمت‌های مجاز برای ویدیو: mp4, mov, avi")]
        public List<IFormFile> VideoFiles { get; set; } = new();

        [BindProperty]
        public DateTime ScheduleDate { get; set; }

        [BindProperty]
        [Url(ErrorMessage = "فرمت لینک نامعتبر است")]
        public string? Link { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "Slug الزامی است")]
        [RegularExpression("^[a-z0-9-]+$", ErrorMessage = "فقط حروف کوچک، اعداد و خط تیره مجاز است")]
        public string Slug { get; set; }

        public async Task<IActionResult> OnGet(long chatId)
        {
            ChatId = chatId;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _service.Add(new Models.SocialMedia.Telegram.Post.
                AddPostCommand(ChatId, ScheduleDate, Description, Link, Slug, ImageFiles, VideoFiles));

            return Page();
        }
        private static string FormatDateTime(DateTime dateTime)
        {
            string dayOfWeek = dateTime.ToString("ddd", new CultureInfo("en-US"));
            string month = dateTime.ToString("MMM", new CultureInfo("en-US"));
            string day = dateTime.Day.ToString("00");
            string year = dateTime.Year.ToString();
            string time = dateTime.ToString("HH:mm:ss");
            string timeZone = dateTime.ToString("zzz");/*{timeZone}*/
            return $"{dayOfWeek} {month} {day} {year} {time} GMT {timeZone} (Iran Standard Time)";
        }
    }
}
