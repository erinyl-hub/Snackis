using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis.Models;
using Snackis.Models.Postings;

namespace Snackis.Pages.RoleUser
{
    public class CategoriePageModel : PageModel
    {
        private readonly MyDbContext _context;

        public CategoriePageModel(MyDbContext context)
        {
            _context = context;
        }

        public Categorie Categorie { get; set; }
        public List<Heading> Heading { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            Categorie = category;
            Heading = await _context.Headings
                .Where(heading => heading.CategorieId == Categorie.Id)
                .ToListAsync();

            return Page();
        }
    }
}
