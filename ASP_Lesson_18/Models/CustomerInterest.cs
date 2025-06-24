namespace ASP_Lesson_18.Models
{
    public class CustomerInterest
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
