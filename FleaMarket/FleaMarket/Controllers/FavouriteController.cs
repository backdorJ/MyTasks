using FleaMarket.Authoriz;
using FleaMarket.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FleaMarket.Controllers;

public class FavouriteController : Controller
{
    private readonly IAnnouncementsRepository _repository;
    private readonly UserManager<ApplicationUser> _userManager;

    public FavouriteController(
        IAnnouncementsRepository repository,
        UserManager<ApplicationUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetViewFavourites()
    {
        var userId = _userManager.GetUserId(User);
        return View(await _repository.GetAllAnnouncementsByIdUserAsync(userId));
    }
}