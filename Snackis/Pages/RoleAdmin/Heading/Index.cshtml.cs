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
    public class IndexModel : PageModel
    {
        private readonly Snackis.Models.MyDbContext _context;

        public IndexModel(Snackis.Models.MyDbContext context)
        {
            _context = context;
        }

        public IList<Models.Postings.Heading> Heading { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Heading = await _context.Headings
                .Include(h => h.Categorie).ToListAsync();
        }
    }
}
