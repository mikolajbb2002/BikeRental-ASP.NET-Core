using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Views.Home;

public class Student : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}