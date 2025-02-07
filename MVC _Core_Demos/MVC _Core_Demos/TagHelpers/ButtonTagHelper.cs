using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json.Linq;

namespace MVC__Core_Demos.Taghelpers
{
    [HtmlTargetElement("mybutton")]
    public class ButtonTagHelper : TagHelper
    {
        public string Type { get; set; } = "button";
        public string Value { get; set; } = "btn btn-primary";

        public override void Process(TagHelperContext context,
            TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.Add("type", Type);
            output.Attributes.Add("value", Value);

            output.Content.SetContent(Value);

             output.TagMode = TagMode.StartTagAndEndTag;
            output.TagMode = TagMode.SelfClosing;
        }
    }
}
