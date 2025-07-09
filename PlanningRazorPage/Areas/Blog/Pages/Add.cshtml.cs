using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Infrastructure.Utils;
using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Blog;
using PlanningRazorPage.Models.Category;
using PlanningRazorPage.Services.Blog;
using PlanningRazorPage.Services.Category;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace PlanningRazorPage.Areas.Blog
{
    [BindProperties]
    [Area("Blog")]
    public class AddModel : BaseRazorPage
    {
        private readonly IBlogService _service;
        private readonly ICategoryService _categoryService;

        public AddModel(ICategoryService categoryService, IBlogService service)
        {
            _categoryService = categoryService;
            _service = service;
        }

        [Display(Name = "slug")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        public string Slug { get; set; }
        [Display(Name = "image")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        public IFormFile Image { get; set; }
        [Display(Name = "SendTime")]
        public string? SendTime { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [UIHint("ckEditor")]
        public string Description { get; set; }
        //public string CreatorUserName { get; set; }
        [Display(Name = "SeoData")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        public SeoData SeoData { get; set; } = new SeoData();
        public bool IsSend { get; set; }
        [Display(Name = "category")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        public long CategoryId { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<CategoryDto?> Categories { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Categories = await _categoryService.GetList();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            DateTime date = DateTime.Now;
            if (SendTime != null)
            {
                date = SendTime!.ConvertToGregorianDateTime();

            }
            var result = await _service.Create(new AddBlogCommand
            {
                Image = Image,
                Title = Title,
                Slug = Slug,
                Description = Description,
                CategoryId = CategoryId,
                SendTime = date,
                SeoData = SeoData,
                CreatorUserName = User.GetUserName(),
                IsSend = false
            });
            //if (result!.IsSuccess)
            return RedirectAndShowAlert(result, Redirect("List"));

            //ModelState.AddModelError("", "خطا در ویرایش وبلاگ");
            //Categories = await _categoryService.GetList();
            //ErrorAlert();
            //return Page();
        }
    }
}