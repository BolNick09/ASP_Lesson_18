using ASP_Lesson_18.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages
{
    public class AllCountriesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AllCountriesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CountryInfo> Countries { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var customersByCountry = await _context.Customers
                .GroupBy(c => c.Country)
                .Select(g => new { Country = g.Key, Count = g.Count() })
                .ToListAsync();

            var promotionsByCountry = await _context.Promotions
                .GroupBy(p => p.Country)
                .Select(g => new { Country = g.Key, Count = g.Count() })
                .ToListAsync();

            Countries = customersByCountry
                .Select(c => new CountryInfo
                {
                    CountryName = c.Country,
                    CustomersCount = c.Count,
                    PromotionsCount = promotionsByCountry.FirstOrDefault(p => p.Country == c.Country)?.Count ?? 0
                })
                .OrderBy(c => c.CountryName)
                .ToList();
        }

        public class CountryInfo
        {
            public string CountryName { get; set; } = default!;
            public int CustomersCount { get; set; }
            public int PromotionsCount { get; set; }
        }
    }
}
