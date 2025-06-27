using ASP_Lesson_18.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages
{
    public class AllCitiesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AllCitiesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Dictionary<string, int> Cities { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Cities = await _context.Customers
                .GroupBy(c => c.City)
                .Select(g => new { City = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.City, x => x.Count);
        }
    }
}
