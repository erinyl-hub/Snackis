using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis.Areas.Identity.Data;
using Snackis.Dtos;
using Snackis.Models;
using Snackis.Models.Postings;
using System.ComponentModel.Design;

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

        public List<CommentDto> Comments;

        [BindProperty]
        public Dtos.ViewInPostDto Post { get; set; }

        [BindProperty]
        public Models.Postings.Comment Comment { get; set; }

        

        public async Task<IActionResult> OnGetAsync(int id)
        {


            Post = await GetPostAsync(id);
            Comments = await GetCommentsAsync(id);


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int CommentId)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                Comment.CommentDate = DateTime.Now;
                Comment.UserId = _userManager.GetUserId(User);
                Comment.PostId = Post.Id;
                Comment.ParentCommentId = CommentId;

                await _context.AddAsync(Comment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(null, new { id = Post.Id });
        }


        public async Task<ViewInPostDto> GetPostAsync(int postId)
        {

            return await _context.Posts
                 .Include(p => p.SnackisUser)
                 .Where(p => p.Id == postId)
                 .Select(p => new Dtos.ViewInPostDto
                 {
                     Id = p.Id,
                     Header = p.PostHeading,
                     Text = p.PostText,
                     CreatedOn = p.PostDate,
                     UserName = p.SnackisUser.UserName,
                     UserId = p.SnackisUser.Id,
                     Image = p.PostImage,
                 }).FirstOrDefaultAsync();

        }

        public async Task<List<CommentDto>> GetCommentsAsync(int postId)
        {

            return await _context.Comments
                .Where(c => c.PostId == postId)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    Text = c.CommentText,
                    CreatedOn = c.CommentDate,
                    UserName = c.SnackisUser.UserName,
                    UserId = c.SnackisUser.Id,
                    Image = c.CommentImage,
                    ParentComment = c.ParentComment == null ? null : new CommentDto
                    {
                        Id = c.ParentComment.Id,
                        Text = c.ParentComment.CommentText,
                        CreatedOn = c.ParentComment.CommentDate,
                        UserName = c.ParentComment.SnackisUser.UserName,
                        UserId = c.ParentComment.SnackisUser.Id,
                        Image = c.ParentComment.CommentImage
                    }


                })
                .ToListAsync();


        }
    }
}
