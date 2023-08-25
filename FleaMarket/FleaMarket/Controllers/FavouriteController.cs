using FleaMarket.Authoriz;
using FleaMarket.Interfaces;
using FleaMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FleaMarket.Controllers;

public class FavouriteController : Controller
{
    private readonly IAnnouncementsRepository _repository;
    private readonly IRecipeRepository _recipeRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public FavouriteController(
        IAnnouncementsRepository repository,
        UserManager<ApplicationUser> userManager,
        IRecipeRepository recipeRepository)
    {
        _repository = repository;
        _userManager = userManager;
        _recipeRepository = recipeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetViewFavourites()
    {
        var userId = _userManager.GetUserId(User);
        var annous = await _repository.GetAllAnnouncementsByIdUserAsync(userId);
        var recipes = await _recipeRepository.GetAllRecipesByIdUserAsync(userId);
        return View(new AnnouncementAndRecipesFavouriteModel(){AnnouncementModels =  annous, RecipeModel = recipes});
    }

    [HttpGet]
    public async Task<IActionResult> DeleteFavouriteItem(int id)
    {
        var userId = _userManager.GetUserId(User);
        var result = await _repository.DeleteAnnouncementAsync(id, userId);
        if (result)
            return RedirectToAction("GetViewFavourites", "Favourite");
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> DeleteFavouriteRecipe(int id)
    {
        var userId = _userManager.GetUserId(User);
        var result = await _recipeRepository.DeleteRecipeByIdUserAsync(id, userId);
        await _recipeRepository.DeleteRecipeInDatabaseAsync(id);
        if (result)
            return RedirectToAction("GetViewFavourites", "Favourite");
        return View();
    }
}