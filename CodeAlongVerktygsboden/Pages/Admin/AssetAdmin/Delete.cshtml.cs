using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodeAlongVerktygsboden.Data;
using CodeAlongVerktygsboden.Models;

namespace CodeAlongVerktygsboden.Pages.Admin.AssetAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly CodeAlongVerktygsboden.Data.CodeAlongVerktygsbodenContext _context;

        public DeleteModel(CodeAlongVerktygsboden.Data.CodeAlongVerktygsbodenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asset Asset { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset.FirstOrDefaultAsync(m => m.Id == id);

            if (asset is not null)
            {
                Asset = asset;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset.FindAsync(id);
            if (asset != null)
            {
                Asset = asset;
                _context.Asset.Remove(Asset);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
