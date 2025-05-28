using CodeAlongVerktygsboden.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CodeAlongVerktygsboden.Pages;

public class IndexModel : PageModel
{
    private readonly CodeAlongVerktygsbodenContext _context;

    public IndexModel(CodeAlongVerktygsbodenContext context)
    {
        _context = context;
    }

    public List<Models.Asset> Assets { get; set; }
    public List<Models.Booking> AllBookings { get; set; }

    public async Task OnGetAsync()
    {
        Assets = await _context.Asset.ToListAsync();
    }
}
