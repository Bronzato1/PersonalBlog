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
    public class ButtonColorForRoleTagHelper : TagHelper
    {
        private const string ForAttributeName = "button-color-for-role";
        private readonly UserManager<CustomUser> _userManager;

        public ButtonColorForRoleTagHelper(UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
        }

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var isAdmin = await _userManager.IsInRoleAsync((CustomUser)For.Model, "Admin");
            var isAuthor = await _userManager.IsInRoleAsync((CustomUser)For.Model, "Author");
            var isVisitor = await _userManager.IsInRoleAsync((CustomUser)For.Model, "Visitor");

            var color = String.Empty;

            if (isAdmin)
                color = "btn-outline-light";
                
            if (isAuthor)
                color = "btn-outline-dark";
                
            if (isVisitor)
                color = "btn-outline-dark";
             
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