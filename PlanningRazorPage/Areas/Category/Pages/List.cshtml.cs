using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Category;
using PlanningRazorPage.Services.Category;

namespace PlanningRazorPage.Areas.Category
{
    [Area("Category")]
    public class ListModel : BaseRazorFilter<CategoryFilterParam>
    {
        private readonly ICategoryService _service;

        public ListModel(ICategoryService service)
        {
            _service = service;
        }
        public CategoryFilterResult categories { get; set; }
        public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
        {
            var result = await _service.GetList();
            if (result != null)
            {
                categories = await result!.MapCategoryDtoFilter
                    (FilterParams, cancellationToken);
            }

            return Page();
        }
        public async Task<IActionResult> OnPost(long id)
        {
            var result = await _service.Delete(id);
            return RedirectAndShowAlert(result, Page());
        }
    }
}
