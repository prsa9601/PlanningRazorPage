using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models.Package;
using PlanningRazorPage.Services.Package;

namespace PlanningRazorPage.Pages.Admin.Package
{
    
    public class EditModel : BaseRazorPage
    {
        private readonly IPackageService _service;

        public EditModel(IPackageService service)
        {
            _service = service;
        }
        [BindProperty]
        public string title { get; set; }
        [BindProperty]
        public long id { get; set; }
        [BindProperty]
        public string Link { get; set; }
        [BindProperty]
        public ExpiryTime expiryTime { get; set; }
        [BindProperty]
        public int AllowedEmailCount { get; set; }
        [BindProperty]
        public int AllowedSmsCount { get; set; }
        [BindProperty]
        public int price { get; set; }
        [BindProperty]
        public bool active { get; set; } = false; 
        [BindProperty]
        public List<string> Keys { get; set; } = new(); 
        [BindProperty]
        public List<string> Values { get; set; } = new();
        [BindProperty]
        public IFormFile Picture { get; set; }

        public async Task<IActionResult> OnGet(long id)
        {
            var result = await _service.GetPackage(id);
            id = result.Id;
            title = result.Title;
            Link = result.Link;
            AllowedSmsCount = result.AllowedSmsCount;
            AllowedEmailCount = result.AllowedEmailCount;
            //ExpiryTime = result.ExpiryTime;
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
                AllowedEmailCount = AllowedEmailCount,
                AllowedSmsCount = AllowedSmsCount,
                ExpiryTime = expiryTime,
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
