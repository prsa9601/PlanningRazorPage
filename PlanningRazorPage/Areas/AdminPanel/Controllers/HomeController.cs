using Microsoft.AspNetCore.Mvc;
using PlanningRazorPage.Models.Blog;

namespace PlanningRazorPage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
