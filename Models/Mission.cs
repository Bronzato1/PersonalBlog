using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public partial class Mission : Auditable
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EnumSector Sector { get; set; }
        public int Staff { get; set; }
        public int CompanyId { get; set; }
        public int? DatabaseId { get; set; }
        
        public virtual Company Company { get; set; }
        public virtual Database Database { get; set; }
        public virtual List<MissionLanguage> MissionLanguages { get; set; }
    }
}