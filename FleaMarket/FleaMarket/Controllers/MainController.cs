using FleaMarket.API.Interaces;
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
    private readonly IBeerRepository _beerRepo;
    private readonly IUserRepository _userRepository;
    private readonly IFoodRepository _foodRepository;
    private readonly IRecipeRepository _recipeRepository;

    public MainController(
        IAnnouncementsRepository repository,
        UserManager<ApplicationUser> userManager,
        IBeerRepository beerRepo,
        IUserRepository userRepository,
        IFoodRepository foodRepository,
        IRecipeRepository recipeRepository)
    {
        _repository = repository;
        _userManager = userManager;
        _beerRepo = beerRepo;
        _userRepository = userRepository;
        _foodRepository = foodRepository;
        _recipeRepository = recipeRepository;
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
    public async Task<IActionResult> ViewBeerCategory()
    {
        return View(await _beerRepo.GetBeersAsync(100));
    }

    [HttpGet]
    public async Task<IActionResult> ViewRecipeCategory()
    {
        var recipes = await _foodRepository.GetAllFoodsAsync(100);
        return View(recipes);
    }

    [HttpGet]
    public async Task<IActionResult> ViewDetailRecipe(int id)
    {
        var detailRecipe = await _foodRepository.GetDetailRecipe(id);
        return View(detailRecipe);
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> AddToFavouriteRecipe(int id)
    {
        var recipe = await _foodRepository.GetDetailRecipe(id);
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            if (recipe != null)
            {
                var model = new RecipesUsers()
                {
                    RecipeId = recipe.Id,
                    UserId = user.Id
                };

                await _recipeRepository.AddedInDatabaseRecipeAsync(recipe);
                await _recipeRepository.AddRecipeInFavouriteAsync(model);
                return RedirectToAction("GetViewFavourites", "Favourite");
            }
        }
        
        return RedirectToAction("ViewAnnouncements", "Main");
    }

    [HttpGet]
    public async Task<IActionResult> ViewEmploymentsCompany()
    {
        return View(await _userRepository.GetUsersAsync(100));
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
                var model = new AnnouncementsUsers()
                {
                    UserId = user.Id,
                    AnnouncementId = announcement.Id,
                    IsAdded = true
                };
                await _repository.AddToFavouriteAsync(model);
                return RedirectToAction("GetViewFavourites", "Favourite");
            }
        }
        return RedirectToAction("ViewAnnouncements", "Main");
    }
}