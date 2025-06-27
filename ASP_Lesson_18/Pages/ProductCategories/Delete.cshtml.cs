using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages.ProductCategories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProductCategories == null)
            {
                return NotFound();
            }
            var productcategory = await _context.ProductCategories.FindAsync(id);

            if (productcategory != null)
            {
                ProductCategory = productcategory;
                _context.ProductCategories.Remove(ProductCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
