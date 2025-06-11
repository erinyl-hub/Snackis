using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snackis.Areas.Identity.Data;
using Snackis.Models;
using Snackis.Services;

namespace Snackis.Pages.RoleUser
{
    public class SendMsgPageModel : PageModel
    {


        private readonly UserManager<SnackisUser> _userManager;
        private readonly MyDbContext _context;
        private readonly MyService _myService;
        public SendMsgPageModel
                  (UserManager<SnackisUser> userManager, MyDbContext context, Services.MyService myService)
        {
            _userManager = userManager;
            _context = context;
            _myService = myService;
        }

        public Models.Messages.Message Message { get; set; }




        public async Task OnGetAsync(string id)
        {
            Message.ReceiverId =  id;
            Console.WriteLine();

        }
    }
}
