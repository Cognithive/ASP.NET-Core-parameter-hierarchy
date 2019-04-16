namespace ParameterHierarchy
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("a")]
    public class ParametersTagHelper : TagHelper
    {
        public Parameters Parameters { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("href", Parameters);
        }
    }
}
