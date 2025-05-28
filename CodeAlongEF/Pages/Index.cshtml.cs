using CodeAlongEF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CodeAlongEF.Pages;

public class IndexModel : PageModel
{
    public List<Models.Car> MyCars{ get; set; }
    public Areas.Identity.Data.CodeAlongEFUser MyUser { get; set; }

    private readonly MyDbContext _myDbContext;
    private UserManager<Areas.Identity.Data.CodeAlongEFUser> _userManager;

    public IndexModel(MyDbContext myDbContext, UserManager<Areas.Identity.Data.CodeAlongEFUser> userManager)
    {
        _myDbContext = myDbContext;
        _userManager = userManager;
    }


    public async Task OnGetAsync()
    {
        DbSet<Car> myCars = _myDbContext.Cars;

        myCars.Add(new Car { Make = "Volvo", Plate = "ABC" + Random.Shared.Next(100, 999) });
        _myDbContext.SaveChanges();
        MyCars = await _myDbContext.Cars.ToListAsync();


        MyUser = await _userManager.GetUserAsync(User);
    }
}
