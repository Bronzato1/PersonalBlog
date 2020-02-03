namespace PersonalBlog.Models
{
    public partial class Company : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}