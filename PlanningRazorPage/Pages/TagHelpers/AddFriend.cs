using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PlanningRazorPage.Pages.TagHelpers
{
    public class AddFriend : TagHelper
    {
        public string Url { get; set; }

        public string userName { get; set; }
        public string Description { get; set; } = "";

        public string Class { get; set; } = "";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("onClick", $"AddFriend('{Url}','{Description}')");
            output.Attributes.Add("class", Class);
            base.Process(context, output);
        }

    }
}
