using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages
{
    public class PromotionsByCountryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PromotionsByCountryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Promotion> Promotions { get; set; } = default!;
        public string Country { get; set; } = default!;

        public async Task OnGetAsync(string country)
        {
            Country = country;
            Promotions = await _context.Promotions
                .Include(p => p.ProductCategory)
                .Where(p => p.Country == country)
                .OrderByDescending(p => p.EndDate)
                .ToListAsync();
        }
    }
}
