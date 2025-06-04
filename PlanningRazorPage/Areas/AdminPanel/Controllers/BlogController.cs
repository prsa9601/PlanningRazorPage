using Microsoft.AspNetCore.Mvc;
using PlanningRazorPage.Models.Blog;

namespace PlanningRazorPage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View(new AddBlogCommandViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddBlogCommandViewModel model)
        {
            return View();
        }
    }
}
