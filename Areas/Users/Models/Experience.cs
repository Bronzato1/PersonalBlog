using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public partial class Experience : Auditable
    {
        public int Id { get; set; }
        public string CustomUserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EnumSector Sector { get; set; }
        public int Staff { get; set; }
        public int Duration { get; set; }
        public int CompanyId { get; set; }
        
        public virtual CustomUser CustomUser { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<ExperienceKeyword> ExperienceKeywords { get; set; }
    }
}