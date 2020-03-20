using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PersonalBlog.Models;

namespace PersonalBlog.TagHelpers
{
    [HtmlTargetElement("*", Attributes = ForAttributeName)]
    public class CircleColorForLevelTagHelper : TagHelper
    {
        private const string ForAttributeName = "circle-color-for-level";

        public CircleColorForLevelTagHelper()
        {
        }

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var level = (int) For.Model;

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var color = String.Empty;

            if (level==1)
                color = "level-1-user";
                
            if (level==2)
                color = "level-2-user";
                
            if (level==3)
                color = "level-3-user";

            if (level==4)
                color = "level-4-user";

            var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");

            if (classAttr == null)
            {
                classAttr = new TagHelperAttribute("class", color);
                output.Attributes.Add(classAttr);
            }
            else
            {
                //output.Attributes.SetAttribute("class", color);
                var curValue = classAttr.Value.ToString();
                output.Attributes.SetAttribute("class", curValue + " " + color);
            }
        }
    }
}   