using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models;
using PlanningRazorPage.Models.Category;
using PlanningRazorPage.Services.Category;
using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Areas.Category
{
    [Area("Category")]
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly ICategoryService _service;

        public AddModel(ICategoryService service)
        {
            _service = service;
        }

        //[Display(Name = "Title")]
        public string Title { get; set; }
        //[Display(Name = "Slug")]
        public string Slug { get; set; }
        //[Display(Name = "SeoData")]
        public SeoData seoData { get; set; } = new SeoData();
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _service.Create(new CreateCategoryCommand(Title, Slug, seoData));
            if (result!.IsSuccess == false)
            {
                Slug = Slug;
                Title = Title;
                seoData = seoData;
                return Page();
            }
            return RedirectAndShowAlert(result, RedirectToPage("List"));
        }
    }
}
