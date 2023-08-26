using Microsoft.AspNetCore.Mvc;

namespace FleaMarket.Controllers;

public class ProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}