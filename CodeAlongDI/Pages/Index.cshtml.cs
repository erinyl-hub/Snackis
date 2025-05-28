using CodeAlongDI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeAlongDI.Pages;

public class IndexModel : PageModel
{

    public List<string> Outputs { get; set; } = new List<string>();

    private UtilitiesToBeTransient _utilitiesTransient1;
    private UtilitiesToBeTransient _utilitiesTransient2;

    private UtilitesToBeScoped _utilitiesToBeScoped1;
    private UtilitesToBeScoped _utilitiesToBeScoped2;

    private UtilitesToBeSingeleton _utilitiesToBeSingeleton1;
    private UtilitesToBeSingeleton _utilitiesToBeSingeleton2;


    public IndexModel(
        UtilitiesToBeTransient utilitiesTransient1, UtilitiesToBeTransient utilitiesTransient2,
        UtilitesToBeScoped utilitesToBeScoped1, UtilitesToBeScoped utilitesToBeScoped2,
        UtilitesToBeSingeleton utilitiesToBeSingeleton1, UtilitesToBeSingeleton utilitiesToBeSingeleton2)
    {
        _utilitiesTransient1 = utilitiesTransient1;
        _utilitiesTransient2 = utilitiesTransient2;

        _utilitiesToBeScoped1 = utilitesToBeScoped1;
        _utilitiesToBeScoped2 = utilitesToBeScoped2;

        _utilitiesToBeSingeleton1 = utilitiesToBeSingeleton1;
        _utilitiesToBeSingeleton2 = utilitiesToBeSingeleton2;
    }





    public void OnGet()
    {
        //Gamla sättet, med new
        Services.Utilities utilitiesOldWay = new Services.Utilities();
        utilitiesOldWay.Message = "Hej från UtilitiesOldWay";
        Outputs.Add(utilitiesOldWay.Message + ": " + utilitiesOldWay.GetDate() + ", " + utilitiesOldWay.GetRandomInt());


        //DI, Transient
        _utilitiesTransient1.Message = "Hej via DI som Transite1";
        Outputs.Add(_utilitiesTransient1.Message + ": " + _utilitiesTransient1.GetDate() + ", " +  _utilitiesTransient1.GetRandomInt());

        _utilitiesTransient2.Message = "Hej via DI som Transite2";
        Outputs.Add(_utilitiesTransient2.Message + ": " + _utilitiesTransient2.GetDate() + ", " + _utilitiesTransient2.GetRandomInt());

        //DI, Scoped
        _utilitiesToBeScoped1.Message = "Hej vi DI som Scoped1";
        Outputs.Add(_utilitiesToBeScoped1.Message + ": " + _utilitiesToBeScoped1.GetDate() + ", " + _utilitiesToBeScoped1.GetRandomInt());

        _utilitiesToBeScoped2.Message = "Hej vi DI som Scoped2";
        Outputs.Add(_utilitiesToBeScoped2.Message + ": " + _utilitiesToBeScoped2.GetDate() + ", " + _utilitiesToBeScoped2.GetRandomInt());

        //DI , Singeleton
        _utilitiesToBeSingeleton1.Message = "Hej vi DI som Singeleton1";
        Outputs.Add(_utilitiesToBeSingeleton1.Message + ": " + _utilitiesToBeSingeleton1.GetDate() + ", " + _utilitiesToBeSingeleton1.GetRandomInt());

        _utilitiesToBeSingeleton2.Message = "Hej vi DI som Singeleton2";
        Outputs.Add(_utilitiesToBeSingeleton2.Message + ": " + _utilitiesToBeSingeleton2.GetDate() + ", " + _utilitiesToBeSingeleton2.GetRandomInt());

    }
}
