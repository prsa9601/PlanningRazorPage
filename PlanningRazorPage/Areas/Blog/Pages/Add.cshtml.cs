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

namespace PlanningRazorPage.Areas.AdminPanel.Blog
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

        public string Slug { get; set; }
        public IFormFile Image { get; set; }
        public string? SendTime { get; set; }
        public string Title { get; set; }
        [UIHint("ckEditor")]
        public string Description { get; set; }
        //public string CreatorUserName { get; set; }
        public SeoData SeoData { get; set; } = new SeoData();
        public bool IsSend { get; set; }
        public long CategoryId { get; set; }

        public List<CategoryDto?> Categories { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            DateTime date = DateTime.Now;
            if (SendTime != null)
            {
                date = SendTime!.ToMiladi();
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
            if (result!.IsSuccess)
                return RedirectToPage("List");

            ModelState.AddModelError("", "خطا در ویرایش وبلاگ");
            Categories = await _categoryService.GetList();
            return Page();
        }
    }
}