using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages.ProductCategories
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductCategory ProductCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductCategories == null)
            {
                return NotFound();
            }

            var productcategory = await _context.ProductCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (productcategory == null)
            {
                return NotFound();
            }
            else
            {
                ProductCategory = productcategory;
            }
            return Page();
        }
    }
}
