using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis.Areas.Identity.Data;
using Snackis.Models;
using Snackis.Models.Postings;

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


        public List<Dtos.PostViewDto> Posts;

        public async Task<IActionResult> OnGetAsync(int id)
        {


            Posts = await GetPostAsync(id);


            return Page();
        }

        public async Task<List<Dtos.PostViewDto>> GetPostAsync(int headingId)
        {
            List<Dtos.PostViewDto> Posts;

           return await _context.Posts
                .Include(p => p.SnackisUser)
                .Where(p => p.HeadingId == headingId)
                .Select(p => new Dtos.PostViewDto
                {
                    Id = p.Id,
                    Header = p.PostHeading,
                    PostDate = p.PostDate,
                    UserPoster = p.SnackisUser.Name
                }).ToListAsync();

        }




    }
}
