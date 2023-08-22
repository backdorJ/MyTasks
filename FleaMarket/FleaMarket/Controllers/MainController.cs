using FleaMarket.Authoriz;
using FleaMarket.Data;
using FleaMarket.Enum;
using FleaMarket.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FleaMarket.Controllers;

public class MainController : Controller
{
    private readonly IAnnouncementsRepository _repository;
    private readonly UserManager<ApplicationUser> _userManager;
    public MainController(
        IAnnouncementsRepository repository,
        UserManager<ApplicationUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
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

    [HttpGet]
    public async Task<IActionResult> ViewDetailAnnouncement(int id)
    {
        return View(await _repository.GetAnnouncementAsync(id));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> AddToFavourite(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        Log.Information("User id: {id}", user.Id);
        if (user != null)
        {
            var announcement = await _repository.GetAnnouncementAsync(id);
            if (announcement != null)
            {
                Log.Information("Announcment id {id}", announcement.Id);
                var model = new AnnouncementsUsers()
                {
                    UserId = user.Id,
                    AnnouncementId = announcement.Id
                };

                await _repository.AddToFavouriteAsync(model);
                return RedirectToAction("GetViewFavourites", "Favourite");
            }
        }
        return RedirectToAction("ViewAnnouncements", "Main");
    }
}