using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Övning_2___Frissan.Pages
{
    public class AdminModel : PageModel
    {
        [BindProperty]
        public Models.Hairdresser Hairdresser { get; set; }

        public Models.Hairdressers hairdressers = Models.Hairdressers.GetHairdressersInstance();


        public void OnGet()
        {
            //Hairdresser = new Models.Hairdresser();
        }

        public void OnPost()
        {
            hairdressers.hairdressers.Add(Hairdresser);

            Console.WriteLine("Test");



        }
    }
}
