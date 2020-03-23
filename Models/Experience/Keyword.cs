using System.Collections.Generic;

namespace PersonalBlog.Models
{
    public partial class Keyword : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnumColor Color { get; set; }
        public virtual List<ExperienceKeyword> ExperienceKeywords { get; set; }
    }
}