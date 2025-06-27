using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages
{
    public class AllCustomersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AllCustomersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers.ToListAsync();
        }
    }
}
