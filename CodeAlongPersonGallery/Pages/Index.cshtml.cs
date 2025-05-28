using CodeAlongPersonGallery.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeAlongPersonGallery.Pages;

public class IndexModel : PageModel
{
    public List<Models.Person> AllPersons { get; set; } 

    public async Task OnGetAsync()
    {
        AllPersons = await PersonManager.GetAllPersons();

    }
}
