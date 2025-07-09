using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Models.Blog
{
    public class AddBlogCommand
    {
        public string Slug { get; set; }
        public IFormFile Image { get; set; }
        public DateTime SendTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatorUserName { get; set; }
        public SeoData SeoData { get; set; }=new SeoData();
        public bool IsSend { get; set; }
        public long CategoryId { get; set; }
    }
    public class AddBlogCommandViewModel
    {
        public string Slug { get; set; }
        public IFormFile Image { get; set; }
        public string SendTime { get; set; }
        public string Title { get; set; }
        [UIHint("ckEditor")]
        public string Description { get; set; }
        public string CreatorUserName { get; set; }
        public SeoData SeoData { get; set; }=new SeoData();
        public bool IsSend { get; set; }
        public long CategoryId { get; set; }
    }
    public class EditBlogCommand
    {
        public long BlogId { get; set; }
        public string Slug { get; set; }
        //public IFormFile? Image { get; set; }
        public DateTime SendTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatorUserName { get; set; }
        public SeoData SeoData { get; set; }
        public bool IsSend { get; set; }
        public long CategoryId { get; set; }
    }
    public class SetImageBlogCommand
    {
        public IFormFile Image { get; set; }
        public long Id { get; set; }
    }
    public class IncreaseBlogVisitCommand 
    {
        public long BlogId { get; set; }
    }
    public class RemoveBlogCommand 
    {
        public long BlogId { get; set; }
    }
}
