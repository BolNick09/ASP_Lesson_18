using ASP_Lesson_18.Data;
using ASP_Lesson_18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lesson_18.Pages.Promotions
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Promotion Promotion { get; set; } = default!;

        public SelectList ProductCategories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            ProductCategories = new SelectList(await _context.ProductCategories.ToListAsync(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ProductCategories = new SelectList(await _context.ProductCategories.ToListAsync(), "Id", "Name");
                return Page();
            }

            _context.Promotions.Add(Promotion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
