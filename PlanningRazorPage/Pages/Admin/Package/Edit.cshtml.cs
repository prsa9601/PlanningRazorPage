using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Services.Package;

namespace PlanningRazorPage.Pages.Admin.Package
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly IPackageService _service;

        public EditModel(IPackageService service)
        {
            _service = service;
        }

        public string title { get; set; }
        public long id { get; set; }
        public string Link { get; set; }
        public int price { get; set; }
        public bool active { get; set; } = false;
        public List<string> Keys { get; set; } = new();
        public List<string> Values { get; set; } = new();
        public IFormFile Picture { get; set; }

        public async Task<IActionResult> OnGet(long id)
        {
            var result = await _service.GetPackage(id);
            id = result.Id;
            title = result.Title;
            Link = result.Link;
            price = result.Price;
            active = result.Active;
            InitSpecifications(result.Specification);
            return Page(); 
        }

        public async Task<IActionResult> OnPost(long id)
        {
            var result = await _service.Edit(new EditPackageCommand()
            {
                Id = id, 
                Title = title,
                Link = Link,
                Picture = Picture,
                Price = price,
                Specifications = ConvertSpecifications()
            });
            return RedirectAndShowAlert(result, Redirect("List"));
        }
        public void InitSpecifications(List<PackageSpecificationDto> specifications)
        {
            foreach (var specification in specifications)
            {
                Keys.Add(specification.Key);
                Values.Add(specification.Value);
            }
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
