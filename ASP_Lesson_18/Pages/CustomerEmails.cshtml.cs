using ASP_Lesson_18.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages
{
    public class CustomerEmailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CustomerEmailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<string> Emails { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Emails = await _context.Customers
                .Select(c => c.Email)
                .ToListAsync();
        }
    }
}
