using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis.Models;
using Snackis.Models.Postings;

namespace Snackis.Pages.RoleAdmin.Heading
{
    public class DeleteModel : PageModel
    {
        private readonly Snackis.Models.MyDbContext _context;

        public DeleteModel(Snackis.Models.MyDbContext context)
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

            var heading = await _context.Headings.FirstOrDefaultAsync(m => m.Id == id);

            if (heading == null)
            {
                return NotFound();
            }
            else
            {
                Heading = heading;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heading = await _context.Headings.FindAsync(id);
            if (heading != null)
            {
                Heading = heading;
                _context.Headings.Remove(Heading);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
