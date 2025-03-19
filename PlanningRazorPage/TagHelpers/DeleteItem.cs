
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PlanningRazorPage.TagHelpers;

public class DeleteItem : TagHelper
{

    public string Url { get; set; }
 //   public string productid { get; set; }
    public string Description { get; set; } = "";
    public string Class { get; set; } = "Delete";
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.Attributes.Add("onClick", $"CustomDelete('{Url}','{Description}')");
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