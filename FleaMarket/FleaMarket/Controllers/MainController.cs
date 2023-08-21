using FleaMarket.Enum;
using FleaMarket.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FleaMarket.Controllers;

public class MainController : Controller
{
    private readonly IAnnouncementsRepository _repository;

    public MainController(
        IAnnouncementsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> ViewAnnouncements()
    {
        return View(await _repository.GetAnnouncementsAsync());
    }

    [HttpGet]
    public async Task<IActionResult> ViewCarCategory()
    {
        return View(await _repository.GetListModelCategoryAnnouncementsAsync("Car"));
    }
}