using FleaMarket.Authoriz;
using FleaMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FleaMarket.Controllers;

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

    #region Register

        
    [HttpGet]
    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var appUser = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, false);
                return RedirectToAction("ViewAnnouncements", "Main");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        ViewBag.ErrorRegister = true;
        return View(model);
    }

    #endregion

    #region Login Logic
    
    [HttpGet]
    public async Task<IActionResult> Login(string returnUrl)
    {
        return View(new LoginModel(){ReturnUrl = returnUrl});
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
            await _signInManager
                .PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            if (model.ReturnUrl != null && Url.IsLocalUrl(model.ReturnUrl))
                return Redirect(model.ReturnUrl);

            return RedirectToAction("ViewAnnouncements", "Main");
        }

        ViewBag.Error = true;
        return View(model);
    }
    
    #endregion
}