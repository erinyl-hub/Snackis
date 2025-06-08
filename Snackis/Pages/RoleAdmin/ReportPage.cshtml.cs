using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snackis.Areas.Identity.Data;
using Snackis.Models;
using Snackis.Models.Postings;
using Snackis.Services;

namespace Snackis.Pages.RoleAdmin
{
    public class ReportPageModel : PageModel
    {
        private readonly UserManager<SnackisUser> _userManager;
        private readonly MyDbContext _context;
        private readonly MyService _myService;


        public ReportPageModel(UserManager<SnackisUser> userManager, MyDbContext context, MyService myService)
        {
            _userManager = userManager;
            _context = context; 
            _myService = myService;
        }

        public List<Report> Reports { get; set; }

        public async Task OnGetAsync()
        {


            Reports = await _myService.GetReportsAsync();

            return;


        }
    }
}
