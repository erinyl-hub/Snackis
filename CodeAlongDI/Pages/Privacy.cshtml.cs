using CodeAlongDI.Models;
using CodeAlongDI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeAlongDI.Pages;

public class PrivacyModel : PageModel
{

    public string Output { get; set; }

    private MyDbContext _myDbContext;
    private UtilitesToBeSingeleton _utilitiesToBeSingeleton;

    private IUtilities _utilities;

    public PrivacyModel(IUtilities utilities, MyDbContext myDbContext, UtilitesToBeSingeleton utilitesToBeSingeleton)
    {
        _myDbContext = myDbContext;
        _utilitiesToBeSingeleton = utilitesToBeSingeleton;
        _utilities = utilities;
    }


    public void OnGet()
    {
        var myCars = _myDbContext.Cars.ToList();
        _utilities.Message = "Hej från IUtilities";
        Output = _utilities.Message + ": " + _utilities.GetDate() + ", " + _utilities.GetRandomInt();


        int random = _utilitiesToBeSingeleton.GetRandomInt();

    }
}

