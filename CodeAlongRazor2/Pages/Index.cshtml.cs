using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeAlongRazor2.Pages;

public class IndexModel : PageModel
{
    public int Number { get; set; }
    public void OnGet(int selectedNumber)
    {
        Number = selectedNumber;
    }
}
