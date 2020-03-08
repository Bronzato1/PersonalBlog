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
    [HtmlTargetElement("span", Attributes = ForAttributeName)]
    public class DenominationForRoleTagHelper : TagHelper
    {
        private const string ForAttributeName = "denomination-for-role";
        private readonly UserManager<CustomUser> _userManager;

        public DenominationForRoleTagHelper(UserManager<CustomUser> userManager)
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

            var text = String.Empty;

            if (isAdmin)
                text = "Administrator"; 
                
            if (isAuthor)
                text = "Author";
                
            if (isVisitor)
                text = "Visitor"; 
             
            output.Content.SetContent(text);
        }
    }
}   