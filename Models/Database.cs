namespace PersonalBlog.Models
{
    public partial class Database : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnumColor Color { get; set; }
    }
}