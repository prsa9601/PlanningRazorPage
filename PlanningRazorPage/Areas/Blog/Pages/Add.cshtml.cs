using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanningRazorPage.Infrastructure.RazorUtils;
using PlanningRazorPage.Models;
using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Areas.AdminPanel.Blog
{
    [BindProperties]
    [Area("Blog")]
    public class AddModel : BaseRazorPage
    {
        public string Slug { get; set; }
        public IFormFile Image { get; set; }
        public string? SendTime { get; set; }
        public string Title { get; set; }
        [UIHint("ckEditor")]
        public string Description { get; set; }
        //public string CreatorUserName { get; set; }
        public SeoData SeoData { get; set; } = new SeoData();
        public bool IsSend { get; set; }
        public long CategoryId { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            //if (SendTime = nul)
                //SendTime = DateTime.Now();
        }
    }
}
