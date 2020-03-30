using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PersonalBlog.Quizbee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.Quizbee.TagHelpers
{
    [HtmlTargetElement(Attributes = "is-selected")]
    public class IsSelectedOptionTagHelper : TagHelper
    {
        public IsSelectedOptionTagHelper()
        {
        }

        [HtmlAttributeName("is-selected")]
        public ModelExpression SelectedQuizType { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            var selectedQuizType = SelectedQuizType.Model.ToString(); // <-- The quiz type that should be selected by default
            var childContext = output.GetChildContentAsync().Result;
            var content = childContext.GetContent(); // <-- The quiz type for this option (like Text or Image)

            if (selectedQuizType == content)
            {
                output.Attributes.Add(new TagHelperAttribute("selected"));
            }

            output.Attributes.RemoveAll("is-selected");
        }
    }
}
