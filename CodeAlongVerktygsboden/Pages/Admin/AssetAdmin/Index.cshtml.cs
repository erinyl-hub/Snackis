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
    public class IndexModel : PageModel
    {
        private readonly CodeAlongVerktygsboden.Data.CodeAlongVerktygsbodenContext _context;

        public IndexModel(CodeAlongVerktygsboden.Data.CodeAlongVerktygsbodenContext context)
        {
            _context = context;
        }

        public IList<Asset> Asset { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Asset = await _context.Asset.ToListAsync();
        }
    }
}
