using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages
{
    public class CustomersByCountryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CustomersByCountryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; } = default!;
        public string Country { get; set; } = default!;

        public async Task OnGetAsync(string country)
        {
            Country = country;
            Customers = await _context.Customers
                .Where(c => c.Country == country)
                .OrderBy(c => c.City)
                .ThenBy(c => c.FullName)
                .ToListAsync();
        }
    }
}
