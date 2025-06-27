using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Lesson_18.Pages.ProductCategories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductCategory ProductCategory { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.ProductCategories == null || ProductCategory == null)
            {
                return Page();
            }

            _context.ProductCategories.Add(ProductCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
