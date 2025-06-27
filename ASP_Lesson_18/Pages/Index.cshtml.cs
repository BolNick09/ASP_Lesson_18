using ASP_Lesson_18.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public int CustomersCount { get; set; }
    public int CategoriesCount { get; set; }
    public int ActivePromotionsCount { get; set; }
    public int CountriesCount { get; set; }

    public async Task OnGetAsync()
    {
        CustomersCount = await _context.Customers.CountAsync();
        CategoriesCount = await _context.ProductCategories.CountAsync();

        var today = DateTime.Today;
        ActivePromotionsCount = await _context.Promotions
            .Where(p => p.StartDate <= today && p.EndDate >= today)
            .CountAsync();

        CountriesCount = await _context.Customers
            .Select(c => c.Country)
            .Distinct()
            .CountAsync();
    }
}
