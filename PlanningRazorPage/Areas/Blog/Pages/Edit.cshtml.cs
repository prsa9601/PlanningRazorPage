using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Category;
using PlanningRazorPage.Models;
using PlanningRazorPage.Services.Blog;
using PlanningRazorPage.Services.Category;
using System.ComponentModel.DataAnnotations;
using PlanningRazorPage.Models.Blog;
using PlanningRazorPage.Infrastructure;

namespace PlanningRazorPage.Areas.Blog.Pages
{
    [Area("Blog")]
    public class EditModel : BaseRazorPage
    {
        private readonly IBlogService _service;
        private readonly ICategoryService _categoryService;

        public EditModel(IBlogService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsSend { get; set; }
        public string Slug { get; set; }
        [UIHint("ckEditor")]
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public IFormFile Image { get; set; }
        public DateTime SendTime { get; set; }
        public SeoData SeoData { get; set; }

        [BindProperty]
        public List<CategoryDto?> Categories { get; set; }
        public string CurrentImage { get; set; }

        public async Task<IActionResult> OnGet(long id)
        {
            var blog = await _service.GetBlogById(id);
            if (blog == null)
                return RedirectToPage("List");

            // Initialize categories
            Categories = await _categoryService.GetList();

            // Set current image
            CurrentImage = blog.ImageName;

            // Initialize command

            Id = blog.Id;
            Title = blog.Title;
            Slug = blog.Slug;
            Description = blog.Description;
            CategoryId = blog.CategoryId;
            SendTime = blog.SendTime;
            SeoData = blog.SeoData;



            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _service.Edit(new EditBlogCommand
            {
                BlogId = Id,
                Image = Image,
                Title = Title,
                Slug = Slug,
                Description = Description,
                CategoryId = CategoryId,
                SendTime = SendTime,
                SeoData = SeoData,
                CreatorUserName = User.GetUserName(),
                IsSend = IsSend
            });
            if (result!.IsSuccess)
                return RedirectToPage("List");

            ModelState.AddModelError("", "خطا در ویرایش وبلاگ");
            Categories = await _categoryService.GetList();
            return Page();
        }
    }

}