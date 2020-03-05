namespace PersonalBlog.Models
{
    public partial class ExperienceTag : Auditable
    {
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}