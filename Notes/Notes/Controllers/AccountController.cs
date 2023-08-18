using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Authorize;
using Notes.Data;
using Notes.Models;
using Serilog;

namespace Notes.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Register()
    {
        Log.Information("Open register action");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var appUser = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
                AccountOwner = model.UserName
            };
            
            var user = await _userManager.CreateAsync(appUser, model.Password);
            if (user.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, false);
                return RedirectToAction("Index", "Home");
            }
            
            Log.Error("Failed created user");
            foreach (var error in user.Errors)
            {
                ModelState
                    .AddModelError(
                    "",
                    error.Description);
            }
        }

        Log.Error("Invalid model fields {model}", model);
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (user is { Succeeded: true })
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Invalid user");
        }

        Log.Error("Invalid model state");
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
}
