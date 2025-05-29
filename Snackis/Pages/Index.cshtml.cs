using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis.Models;

namespace Snackis.Pages;

public class IndexModel : PageModel
{
    private readonly MyDbContext _context;

    public IndexModel(MyDbContext context)
    {
        _context = context;
    }

    public IList<Models.Postings.Categorie> Categorie { get; set; }

    public async Task OnGetAsync()
    {
        Categorie = await _context.Categories.ToListAsync();

    }
}
