using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PlanningRazorPage.Pages.TagHelpers
{
    public class RemoveActivePackage : TagHelper
    {

        public string Url { get; set; }

        public string id { get; set; }
        public string Description { get; set; } = "";
        public string Class { get; set; } = "dropdown-item ";
        //    public string Class { get; set; } = "Delete";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("onClick", $"PostRemoveActivePackage('{Url}','{Description}')");
            output.Attributes.Add("class", Class);
            base.Process(context, output);
        }
        //public override void Process(TagHelperContext context, TagHelperOutput output)
        //{
        //    output.TagName = "a";
        //    output.Attributes.Add("onClick", $"DeleteItem('{Url}','{Description}')");
        //    output.Attributes.Add("class", Class);
        //    base.Process(context, output);
        //}
    }
}