using System.Collections.Generic;

namespace PersonalBlog.Models
{
    public partial class Tag : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnumColor Color { get; set; }
        public virtual List<ExperienceTag> ExperienceTag { get; set; }
    }
}