using Microsoft.AspNetCore.Mvc;

namespace Notes.Controllers;

public class ProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}