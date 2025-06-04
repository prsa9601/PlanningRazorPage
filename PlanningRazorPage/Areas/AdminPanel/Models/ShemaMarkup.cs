using System.ComponentModel.DataAnnotations;

namespace PlanningRazorPage.Areas.AdminPanel.Models
{
    // Models/SchemaMarkup.cs
    public class SchemaMarkup
    {
        [Display(Name = "نوع Schema")]
        public string Type { get; set; } = "Article";

        [Display(Name = "عنوان اصلی")]
        [Required(ErrorMessage = "عنوان اصلی الزامی است")]
        public string Headline { get; set; }

        [Display(Name = "نویسنده")]
        public string Author { get; set; }

        [Display(Name = "تاریخ انتشار")]
        [DataType(DataType.Date)]
        public DateTime DatePublished { get; set; } = DateTime.Now;

        [Display(Name = "توضیحات کوتاه")]
        public string Description { get; set; }

        [Display(Name = "تصویر اصلی")]
        public string ImageUrl { get; set; }

        [Display(Name = "JSON Schema کامل")]
        [DataType(DataType.MultilineText)]
        public string FullJson { get; set; }
    }
}
