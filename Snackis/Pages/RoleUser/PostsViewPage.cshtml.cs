using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snackis.Areas.Identity.Data;
using Snackis.Models;

namespace Snackis.Pages.RoleUser
{
    public class PostsViewPageModel : PageModel
    {
        private readonly UserManager<SnackisUser> _userManager;
        private readonly MyDbContext _context;
        public PostsViewPageModel
                  (UserManager<SnackisUser> userManager, MyDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        public async Task OnGetAsync()
        {
        }
    }
}
