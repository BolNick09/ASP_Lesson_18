using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages
{
    public class AllPromotionsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AllPromotionsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Promotion> Promotions { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Promotions = await _context.Promotions
                .Include(p => p.ProductCategory)
                .OrderBy(p => p.StartDate)
                .ToListAsync();
        }
    }
}
