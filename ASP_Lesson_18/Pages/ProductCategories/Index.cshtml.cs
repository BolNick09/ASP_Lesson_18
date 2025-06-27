using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages.ProductCategories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ProductCategory> ProductCategories { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ProductCategories != null)
            {
                ProductCategories = await _context.ProductCategories.ToListAsync();
            }
        }
    }
}
