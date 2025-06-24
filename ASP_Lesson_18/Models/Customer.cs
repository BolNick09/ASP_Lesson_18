using System.ComponentModel.DataAnnotations;

namespace ASP_Lesson_18.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Город")]
        public string City { get; set; }

        public ICollection<CustomerInterest> Interests { get; set; } = new List<CustomerInterest>();
    }
}
