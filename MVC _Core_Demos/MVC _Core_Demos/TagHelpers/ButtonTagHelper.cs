using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVC__Core_Demos.Taghelpers
{
    [HtmlTargetElement("mybutton")]
    public class ButtonTagHelper : TagHelper
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.Add("type", Type);
            output.Attributes.Add("value", Value);
        }
    }
}
