using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages
{
    public class AllCategoriesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AllCategoriesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ProductCategory> Categories { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Categories = await _context.ProductCategories
                .Include(pc => pc.Promotions)
                .ToListAsync();
        }
    }
}
