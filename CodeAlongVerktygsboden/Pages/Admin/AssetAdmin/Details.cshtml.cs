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
    public class DetailsModel : PageModel
    {
        private readonly CodeAlongVerktygsboden.Data.CodeAlongVerktygsbodenContext _context;

        public DetailsModel(CodeAlongVerktygsboden.Data.CodeAlongVerktygsbodenContext context)
        {
            _context = context;
        }

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
    }
}
