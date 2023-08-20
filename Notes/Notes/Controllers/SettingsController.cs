using Microsoft.AspNetCore.Mvc;

namespace Notes.Controllers;

public class SettingsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}