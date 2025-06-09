using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Blog;
using PlanningRazorPage.Models.Category;
using PlanningRazorPage.Services.Blog;
using PlanningRazorPage.Services.Category;

namespace PlanningRazorPage.Areas.Blog.Pages
{
    [Area("Blog")]
    public class ListModel : BaseRazorFilter<BlogFilterParam>
    {
        private readonly IBlogService _service;
        private readonly ICategoryService _categoryService;

        public ListModel(IBlogService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }
        [BindProperty(SupportsGet = true)]
        public BlogFilterResult BlogFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<CategoryDto?> CategoryList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            CategoryList = await _categoryService.GetList();
            BlogFilter = await _service.GetBlogByFilter(new BlogFilterParam
            {
                //Title = FilterParams.Title,
                PageId = FilterParams.PageId,
                CategoryId = FilterParams.CategoryId,
                Search = FilterParams.Search,
                SearchOrderBy = FilterParams.SearchOrderBy,
                Slug = FilterParams.Slug,
                Take = FilterParams.Take
            });
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(long id)
        {
            var result = await _service.Remove(id);
            CategoryList = await _categoryService.GetList();
            BlogFilter = await _service.GetBlogByFilter(new BlogFilterParam
            {
                //Title = FilterParams.Title,
                PageId = FilterParams.PageId,
                CategoryId = FilterParams.CategoryId,
                Search = FilterParams.Search,
                SearchOrderBy = FilterParams.SearchOrderBy,
                Slug = FilterParams.Slug,
                Take = FilterParams.Take
            });
            return SuccessAlert(result, Page());
        }
    }
}
