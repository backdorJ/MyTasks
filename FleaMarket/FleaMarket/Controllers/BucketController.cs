using Microsoft.AspNetCore.Mvc;

namespace FleaMarket.Controllers;

public class BucketController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}