using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeAlongMVC.Models;

namespace CodeAlongMVC.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {

        Models.HomeModel myModel = new Models.HomeModel();
        myModel.Header = "Vår personal";
        myModel.Text = "Tveka inte att kontakta oss";

        return View(myModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
