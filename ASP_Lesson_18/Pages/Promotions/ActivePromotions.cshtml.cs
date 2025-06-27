using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages.Promotions
{
    public class ActivePromotionsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ActivePromotionsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Promotion> ActivePromotions { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var today = DateTime.Today;
            ActivePromotions = await _context.Promotions
                .Include(p => p.ProductCategory)
                .Where(p => p.StartDate <= today && p.EndDate >= today)
                .OrderBy(p => p.EndDate)
                .ToListAsync();
        }
    }
}
