using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodeAlongVerktygsboden.Data;
using CodeAlongVerktygsboden.Models;

namespace CodeAlongVerktygsboden.Pages.Admin.BookingAdmin
{
    public class IndexModel : PageModel
    {
        private readonly CodeAlongVerktygsboden.Data.CodeAlongVerktygsbodenContext _context;

        public IndexModel(CodeAlongVerktygsboden.Data.CodeAlongVerktygsbodenContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Booking = await _context.Booking
                .Include(b => b.Asset)
                .Include(b => b.User).ToListAsync();
        }
    }
}
