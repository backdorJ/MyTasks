using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyShop.Authorization;
using MyShop.Interfaces;
using MyShop.Models;
using Serilog;

namespace MyShop.Controllers;

public class ProfileController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<ProfileController> _logger;
    private readonly IBooksRepository _repository;
    private readonly IWebHostEnvironment _environment;

    public ProfileController(
        UserManager<ApplicationUser> userManager,
        ILogger<ProfileController> logger,
        IBooksRepository repository,
        IWebHostEnvironment environment)
    {
        _userManager = userManager;
        _logger = logger;
        _repository = repository;
        _environment = environment;
    }
    
    [HttpGet]
    public async Task<IActionResult> ViewProfile()
    {
        var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
        return View(user);
    }

    [HttpGet]
    public async Task<IActionResult> MyBooks()
    {
        var userId = _userManager.GetUserId(User);
        var books = await _repository.GetBooksForClientAsync(userId);
        return View(books);
    }
    
    [HttpGet]
    public async Task<IActionResult> DeleteBookFromFavourite(int id)
    {
        Log.Information("Open delete favourite book method");
        var userId = _userManager.GetUserId(User);
        await _repository.DeleteFavouriteBookAsync(userId, id);
        return RedirectToAction("MyBooks", "Profile");
    }

    [HttpGet]
    public async Task<IActionResult> ChangePasswordView()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> ChangePasswordView(ChangePasswordViewModel model)
    {
        var userId = _userManager.GetUserId(User);
        var user = await _userManager.FindByIdAsync(userId);
        if (ModelState.IsValid)
        {
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {
                ViewBag.IsSucceed = true;
                ModelState.Clear();
                return View();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            
            
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> EditProfile(EditViewModel model)
    {
        var userId = _userManager.GetUserId(User);
        var user = await _userManager.FindByIdAsync(userId);
        if (ModelState.IsValid)
        {
            user.Gender = model.Gender;

            if (user.PhotoPath != null)
            {
                var pathPhoto = Path.Combine(_environment.WebRootPath, "images", user.PhotoPath);
                System.IO.File.Delete(pathPhoto);
            }
            
            user.PhotoPath = await ProcessFile(model.Photo);
            user.NameUser = model.Username;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                ViewBag.IsSucceed = true;
                ModelState.Clear();
                return View();
            }

            _logger.LogWarning("User do not updated {user}", user);
        }
        
        return View(model);
    }


    private async Task<string> ProcessFile(IFormFile file)
    {
        var unqieString = "";
        if (file != null)
        {
            unqieString = Guid.NewGuid() +  "_" + file.FileName;
            var path = Path.Combine(_environment.WebRootPath,"images", unqieString);
            await using var fs = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(fs);
        }

        return unqieString;
    }
}