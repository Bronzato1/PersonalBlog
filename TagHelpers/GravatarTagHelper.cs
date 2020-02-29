using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PersonalBlog.Models;

namespace PersonalBlog.TagHelpers
{
    [HtmlTargetElement(Attributes = "gravatar-for")]
    public class GravatarTagHelper : TagHelper
    {
        [HtmlAttributeName("gravatar-for")]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            CustomUser user = (CustomUser)For.Model;
            var email = user.UserName.ToLower();

            var emailBytes = Encoding.ASCII.GetBytes(email);
            var hashBytes = new MD5CryptoServiceProvider().ComputeHash(emailBytes);
            var hash = new StringBuilder();

            foreach (var b in hashBytes)
                hash.Append(b.ToString("x2"));

            var imageUrl = string.Format(@"http://www.gravatar.com/avatar/{0}", hash.ToString());
            var srcAttr = output.Attributes.FirstOrDefault(a => a.Name == "src");

            if (srcAttr == null)
            {
                srcAttr = new TagHelperAttribute("src", imageUrl);
                output.Attributes.Add(srcAttr);
            }
            else
            {
                output.Attributes.SetAttribute("src", imageUrl);
            }
        }
    }
}   