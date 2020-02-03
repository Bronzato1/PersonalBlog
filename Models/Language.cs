namespace PersonalBlog.Models
{
    public partial class Language : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnumColor Color { get; set; }
    }
}