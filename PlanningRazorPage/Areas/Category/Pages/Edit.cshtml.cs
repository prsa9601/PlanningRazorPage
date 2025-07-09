using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models;
using PlanningRazorPage.Services.Category;

namespace PlanningRazorPage.Areas.Category
{
    [Area("Category")]
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly ICategoryService _service;

        public EditModel(ICategoryService service)
        {
            _service = service;
        }

        public string Title { get; set; }
        public string Slug { get; set; }
        public long Id { get; set; }
        public SeoData SeoData { get; set; }
        public async Task<IActionResult> OnGet(long id)
        {
            var categoryDto = await _service.GetById(id);
            if (categoryDto == null)
                return Redirect("/Category/List");
            Title = categoryDto.Title;
            Slug = categoryDto.Slug;
            Id = categoryDto.Id;
            SeoData = categoryDto.SeoData;
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _service.Edit(new
                PlanningRazorPage.Models.Category.EditCategoryCommand(
                Id, Title, SeoData, Slug));
            //if (result.IsSuccess == false)
            //{
                //ModelState.AddModelError(string.Empty, result.MetaData.Message);
                //Title = Title;
                //Slug = Slug;
                //Id = Id;
                //SeoData = SeoData;

            //    return Page();
            //}
            return RedirectAndShowAlert(result, RedirectToPage("List"));
        }
    }
}
