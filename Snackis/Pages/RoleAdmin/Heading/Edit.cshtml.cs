using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Snackis.Models;
using Snackis.Models.Postings;

namespace Snackis.Pages.RoleAdmin.Heading
{
    public class EditModel : PageModel
    {
        private readonly Snackis.Models.MyDbContext _context;

        public EditModel(Snackis.Models.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Postings.Heading Heading { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heading =  await _context.Headings.FirstOrDefaultAsync(m => m.Id == id);
            if (heading == null)
            {
                return NotFound();
            }
            Heading = heading;
           ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Heading).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeadingExists(Heading.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HeadingExists(int id)
        {
            return _context.Headings.Any(e => e.Id == id);
        }
    }
}
