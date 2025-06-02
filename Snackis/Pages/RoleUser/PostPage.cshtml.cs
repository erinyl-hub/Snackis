using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis.Areas.Identity.Data;
using Snackis.Dtos;
using Snackis.Models;

namespace Snackis.Pages.RoleUser
{
    public class PostPageModel : PageModel
    {
        private readonly UserManager<SnackisUser> _userManager;
        private readonly MyDbContext _context;


        public PostPageModel
            (UserManager<SnackisUser> userManager, MyDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public SnackisUser CurrentUser { get; set; }

        public List<Dtos.CategorieDto> Categories { get; set; }

        [BindProperty]
        public Models.Postings.Post Post { get; set; }



        public async Task<IActionResult> OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            Categories = await GetCategoriesAsync();
            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                Post.UserId = _userManager.GetUserId(User);
                Post.PostDate = DateTime.Now;

                await _context.AddAsync(Post);
                await _context.SaveChangesAsync();
                return Page();
                //return RedirectToPage("Success");
            }

            if (!ModelState.IsValid)
            {
                Categories = await GetCategoriesAsync();
                return Page();
            }

            return Page();
        }


        private async Task<List<Dtos.CategorieDto>> GetCategoriesAsync()
        {
            return await _context.Categories
                    .Include(c => c.Headings)
                    .Select(c => new CategorieDto
                    {
                        Id = c.Id,
                        CategorieName = c.CategorieName,
                        Headings = c.Headings.Select(h => new HeadingDto
                        {
                            Id = h.Id,
                            HeadingName = h.HeadingName
                        }).ToList()
                    }).ToListAsync();
        }

           


    }
}
