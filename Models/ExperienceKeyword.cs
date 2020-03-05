namespace PersonalBlog.Models
{
    public partial class ExperienceKeyword : Auditable
    {
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }
        public int KeywordId { get; set; }
        public virtual Keyword Keyword { get; set; }
    }
}