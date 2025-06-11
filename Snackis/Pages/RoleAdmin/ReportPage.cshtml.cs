using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackis.Areas.Identity.Data;
using Snackis.Dtos;
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
        public List<Dtos.ReportDto> ReportsDto { get; set; }

        public async Task OnGetAsync()
        {

            Reports = await _myService.GetReportsAsync();
            ReportsDto= await RepDto();
            return;

        }

        public async Task<List<Dtos.ReportDto>> RepDto()
        {
            var commentIds = Reports.Select(r => r.CommentId).Distinct().ToList();

            var comments = await _context.Comments
                .Where(c => commentIds.Contains(c.Id))
                .ToListAsync();

            var reportDtos = Reports.Select(r =>
            {
                var comment = comments.FirstOrDefault(c => c.Id == r.CommentId && r.CommentId != null);

                return new ReportDto
                {
                    Id = r.Id,
                    CommentId = r.CommentId,
                    ReportedBy = r.UserId,
                    Reporter = comment?.UserId,
                    ReportDate = r.ReportDate,
                    Text = comment?.CommentText,
                    ReportId = r.Id

                };
            }).ToList();

            return reportDtos;
        }

        public async Task<IActionResult> OnPostRemoveCommentAsync(int commentId, int reportId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            await _myService.DeleteReportAsync(reportId);
            return RedirectToPage();

        }

        public async Task<IActionResult> OnPostRemoveReportAsync(int reportId)
        {
            await _myService.DeleteReportAsync(reportId);
            return RedirectToPage();
        }
    }
}
