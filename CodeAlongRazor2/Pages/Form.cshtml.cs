using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CodeAlongRazor2.Pages
{
    public class FormModel : PageModel
    {
        public string Result { get; set; }

        [BindProperty]
        
        public string FirstName { get; set; }

        [BindProperty]
        [Display(Name = "Efternamn: ")]
        public string LastName { get; set; }

        [BindProperty]
        [Display(Name = "Nyhetsbrev: ")]
        public bool NewsLetter { get; set; }

        [BindProperty]
        [Display(Name = "Ange skostorlek: ")]
        [DataType(DataType.Text)]
        public int MyNumber { get; set; }

        [BindProperty]
        public DateTime MyDate { get; set; }

        public void OnGet()
        {

            Result = "Ingets har fyllts i formuläret!";

        }

        public void OnPost()
        {
            Result = "Något har skrivits in: " + FirstName + ", " + LastName + ", " + NewsLetter;
            Result += ", " + MyDate;
        }
    }
}
