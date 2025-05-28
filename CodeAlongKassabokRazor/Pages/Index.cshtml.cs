using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeAlongKassabokRazor.Pages;

public class IndexModel : PageModel
{


    public List<Models.Transaction> Transactions { get; set; }

    [BindProperty]
    public Models.Transaction Transaction { get; set; }



    public async Task OnGetAsync(int id)
    {
        Transactions = await DAL.TransactionAPIManager.GetAllTransactions();

        if (id != 0)
        {
            var test = await DAL.TransactionAPIManager.GetTransaction(id);

            if (test != null) // funkar ej
            {
                Transaction = test;
            }
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if(ModelState.IsValid)
        {
            await DAL.TransactionAPIManager.SaveTransaction(Transaction);
        }

        return RedirectToPage("./Index"); //relodar sidan
    }
}
