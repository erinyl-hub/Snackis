using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Snackis.Models;
using Snackis.Models.Postings;

namespace Snackis.Pages.RoleAdmin.Heading
{
    public class CreateModel : PageModel
    {
        private readonly Snackis.Models.MyDbContext _context;

        public CreateModel(Snackis.Models.MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "CategorieName");
            return Page();
        }

        [BindProperty]
        public Models.Postings.Heading Heading { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Headings.Add(Heading);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
