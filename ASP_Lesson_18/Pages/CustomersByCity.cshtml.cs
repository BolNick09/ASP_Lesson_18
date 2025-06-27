using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages
{
    public class CustomersByCityModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CustomersByCityModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; } = default!;
        public string City { get; set; } = default!;

        public async Task OnGetAsync(string city)
        {
            City = city;
            Customers = await _context.Customers
                .Where(c => c.City == city)
                .OrderBy(c => c.FullName)
                .ToListAsync();
        }
    }
}
