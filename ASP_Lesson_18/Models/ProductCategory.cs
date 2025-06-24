namespace ASP_Lesson_18.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CustomerInterest> CustomerInterests { get; set; } = new List<CustomerInterest>();
        public ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
    }
}
