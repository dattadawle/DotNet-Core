using Microsoft.AspNetCore.Razor.TagHelpers;

namespace _2_StateManagement.TagHelpers
{
    [HtmlTargetElement("my-button")]
    public class CustomTagHelper : TagHelper

    {
        public string Type { get; set; }
        public string Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.Add("type", Value);
            output.Attributes.Add("value", Value);

            output.Content.SetContent("Click Me");
        }
    }
}
