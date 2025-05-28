using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CodeAlongEF.Pages.RoleAdmin
{
    public class IndexModel : PageModel
    {
        public List<Areas.Identity.Data.CodeAlongEFUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RoleName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string AddUserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RemoveUserId { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsSuperAdmin { get; set; }



        public UserManager<Areas.Identity.Data.CodeAlongEFUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public IndexModel(RoleManager<IdentityRole> roleManager, UserManager<Areas.Identity.Data.CodeAlongEFUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            Roles = await _roleManager.Roles.ToListAsync();
            Users = await _userManager.Users.ToListAsync();

            if(AddUserId != null)
            {
                var alterUser = await _userManager.FindByIdAsync(AddUserId);
                await _userManager.AddToRoleAsync(alterUser, RoleName);
            }
            if(RemoveUserId != null)
            {
                var alterUser = await _userManager.FindByIdAsync(RemoveUserId);
                await _userManager.RemoveFromRoleAsync(alterUser, RoleName);
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if(currentUser != null)
            {
                IsAdmin = await _userManager.IsInRoleAsync(currentUser, "admin");
                IsSuperAdmin = await _userManager.IsInRoleAsync(currentUser, "superAdmin");


            }


        }


        public async Task<IActionResult> OnPostAsync()
        {

            if(RoleName != null)
            {
                await CreateRole(RoleName);
            }

            return RedirectToPage("./Index");
        }

        public async Task CreateRole(string roleName)
        {
            bool roleExsist = await _roleManager.RoleExistsAsync(roleName);

            if(!roleExsist)
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };

                await _roleManager.CreateAsync(role);
            }


        }
    }
}
