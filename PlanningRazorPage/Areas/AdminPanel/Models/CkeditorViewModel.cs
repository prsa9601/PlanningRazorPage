using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PlanningRazorPage.Areas.AdminPanel.Models
{
    public class CkeditorViewModel
    {
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [UIHint("Ckeditor4")]
        public string Description { get; set; }

    }
}
