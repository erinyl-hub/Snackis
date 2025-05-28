using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Övning_2___Boka_resa_till_Mars.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public int Sum { get; set; }

    [BindProperty]
    public string FirstName { get; set; }

    [BindProperty]
    public string LastName { get; set; }

    [BindProperty]
    public DateTime Departure { get; set; }

    [BindProperty]
    public DateTime Return { get; set; }

    [BindProperty]
    public int BagsCount { get; set; }

    [BindProperty]
    public int Water { get; set; }

    [BindProperty]
    public int Food { get; set; }

    [BindProperty]
    public bool Luxarie { get; set; }

    public Dictionary<string, int> Color { get; set; } = new Dictionary<string, int>
    {{"White", 0 }, {"Red" , 25000 } , {"Black" , 30000 } };

    [BindProperty]
    public string ChosenColor { get; set; }


    public void OnGet()
    {

    }

    public void OnPost() 
    {

        Sum += (int)((Return - Departure).TotalDays * 24000);
        Sum += (BagsCount * 5000);
        Sum += (Water * 150);
        Sum += (Food * 495);
        Sum +=  Luxarie ? 150000 : 0;
        Sum += Color[ChosenColor];
        

        

    }
}
