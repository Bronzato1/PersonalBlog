using System;
using System.Collections.Generic;

namespace PersonalBlog.Models
{
    public partial class Resume : Auditable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EnumSector Sector { get; set; }

        public int CompanyId { get; set; }
        public int DatabaseId { get; set; }
        
        public virtual Company Company { get; set; }
        public virtual Database Database { get; set; }
        public virtual List<Language> Languages { get; set; }
    }
}