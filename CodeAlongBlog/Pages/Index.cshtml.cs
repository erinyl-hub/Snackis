using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace CodeAlongBlog.Pages;

public class IndexModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public IndexModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Models.Blog Blog { get; set; }
    public List<Models.Blog> Blogs { get; set; }
    [BindProperty]
    public IFormFile UploadedImage { get; set; } // Kolla IFormFile


    public async Task OnGetAsync(int deleteId)
    {
        if(deleteId != 0)
        {
            Models.Blog blogToBeDeleted = await _context.Blogs.FindAsync(deleteId);

            if(blogToBeDeleted != null && User.FindFirstValue(ClaimTypes.NameIdentifier) == blogToBeDeleted.UserId)
            {
                string fileName = "./wwwroot/userImages/" + blogToBeDeleted.Image;
                if (System.IO.File.Exists(fileName)) // kolla system.IO..
                {
                    System.IO.File.Delete(fileName);
                }
            }

            _context.Blogs.Remove(blogToBeDeleted);
            await _context.SaveChangesAsync();
        }

        Blogs = await _context.Blogs.ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync() // Kolla Task<IActionResult>
    {
        string fileName = "";

        if(UploadedImage != null)
        {
            fileName = Random.Shared.Next(10000,99999).ToString() + "_" + UploadedImage.FileName;
            using (var fileStream = new FileStream("./wwwroot/userImages" + fileName, FileMode.Create)) // Kolla hela
            {
                await UploadedImage.CopyToAsync(fileStream);

            }
        }

        Blog.Date = DateTime.Now;
        Blog.Image = fileName;
        Blog.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _context.Blogs.Add(Blog);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index"); // Kolla
    }
}
