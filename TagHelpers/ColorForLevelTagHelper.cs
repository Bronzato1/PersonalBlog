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
    public class ColorForLevelTagHelper : TagHelper
    {
        private const string ForAttributeName = "color-for-level";
        private readonly UserManager<CustomUser> _userManager;

        public ColorForLevelTagHelper(UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
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
                color = "level1";
                
            if (level==2)
                color = "level2";
                
            if (level==3)
                color = "level3";

            if (level==4)
                color = "level4";
 
            if (level==5)
                color = "level5";

            if (level==6)
                color = "level6";

            if (level==7)
                color = "level7";

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