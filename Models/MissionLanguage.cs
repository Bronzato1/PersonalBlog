namespace PersonalBlog.Models
{
    public partial class MissionLanguage : Auditable
    {
        public int MissionId { get; set; }
        public virtual Mission Mission { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}