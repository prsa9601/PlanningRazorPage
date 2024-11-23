using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.IdentityModel.Tokens;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Services.Package;

namespace PlanningRazorPage.Pages.Admin.Package
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly IPackageService _service;

        public AddModel(IPackageService service)
        {
            _service = service;
        }
      

        public string Link { get; set; }
        public int Price { get; set; }
        public IFormFile Picture { get; set; }
        public string Title { get; set; }
        [BindProperty]
        public List<string> Keys { get; set; } = new();
        [BindProperty]
        public List<string> Values { get; set; } = new();
   
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _service.Add(new AddPackageCommand()
            {
                Link = Link,
                Picture = Picture,
                Price = Price,
                Specifications = ConvertSpecifications(),
                Title = Title
            });
            if (!result.IsSuccess)
            {
                return Page();
            }

            return RedirectAndShowAlert(result, Redirect("List"));
        }

        private Dictionary<string, string> ConvertSpecifications()
        {
            var specifications = new Dictionary<string, string>();
            Keys.RemoveAll(r => r == null || string.IsNullOrEmpty(r));
            Values.RemoveAll(r => r == null || string.IsNullOrEmpty(r));
            for (int i = 0; i < Keys.Count; i++)
            {
                specifications.Add(Keys[i], Values[i]);
            }
            return specifications;
        }
    }
}
