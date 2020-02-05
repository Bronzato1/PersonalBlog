using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PersonalBlog.TagHelpers
{
    [HtmlTargetElement("p", Attributes = ForAttributeName)]
    public class DisplayForTagHelper : TagHelper
    {
        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var text = For.ModelExplorer.GetSimpleDisplayText();

            if (For.Model is System.DateTime) {
                DateTime date = Convert.ToDateTime(For.Model);
                text = date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            
            output.Content.SetContent(text);
        }
    }
}   