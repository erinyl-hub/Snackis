using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis.Areas.Identity.Data;
using Snackis.Dtos;
using Snackis.Models;
using Snackis.Models.Postings;
using Snackis.Services;
using System.ComponentModel.Design;

namespace Snackis.Pages.RoleUser
{
    public class PostPageModel : PageModel
    {
        private readonly UserManager<SnackisUser> _userManager;
        private readonly MyDbContext _context;
        private readonly MyService _myService;
        public PostPageModel
                  (UserManager<SnackisUser> userManager, MyDbContext context, Services.MyService myService)
        {
            _userManager = userManager;
            _context = context;
            _myService = myService;
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
                if (CommentId != null && CommentId != 0)
                {
                    Comment.ParentCommentId = CommentId;
                }

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
                     UserName = p.SnackisUser.Name,
                     UserId = p.SnackisUser.Id,
                     UserImage = p.SnackisUser.UserImage,
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
                    UserName = c.SnackisUser.Name,
                    UserId = c.SnackisUser.Id,
                    Image = c.SnackisUser.UserImage,
                    ParentComment = c.ParentComment == null ? null : new CommentDto
                    {
                        Id = c.ParentComment.Id,
                        Text = c.ParentComment.CommentText,
                        CreatedOn = c.ParentComment.CommentDate,
                        UserName = c.ParentComment.SnackisUser.Name,
                        UserId = c.ParentComment.SnackisUser.Id,
                        Image = c.ParentComment.SnackisUser.UserImage
                    }
                })
                .ToListAsync();

        }

        public async Task<IActionResult> OnPostPostReportAsync(int postId)
        {
            var report = new Models.Postings.Report
            {
                PoastId = postId,
                ReportDate = DateTime.Now,
                UserId = _userManager.GetUserId(User)
            };

            await _myService.PostReportAsync(report);
            return RedirectToPage(); 
        }

        public async Task<IActionResult> OnPostCommentReportAsync(int commentId)
        {
            var report = new Models.Postings.Report
            {
                CommentId = commentId,
                ReportDate = DateTime.Now,
                UserId = _userManager.GetUserId(User)
            };

            await _myService.PostReportAsync(report);
            return RedirectToPage();
        }
    }
}
