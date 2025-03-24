using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Models.User;
using PlanningRazorPage.Services.User;

namespace PlanningRazorPage.Pages.Admin.User
{
    public class DetailModel : PageModel
    {
        private readonly IUserService _service;

        public DetailModel(IUserService service)
        {
            _service = service;
        }
        public UserDto? user { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {
            user = await _service.GetById(id);
            return Page();
        }
    }
}
