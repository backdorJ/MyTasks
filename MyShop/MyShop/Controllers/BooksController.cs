using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.Authorization;
using MyShop.Interfaces;
using MyShop.Models;

namespace MyShop.Controllers;

[Authorize]
public class BooksController : Controller
{
    private readonly IBooksRepository _repository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAuthenticationService _authService;
    private readonly ILogger<BooksController> _logger;

    public BooksController(
        IBooksRepository repository,
        UserManager<ApplicationUser> userManager,
        IAuthenticationService authService,
        ILogger<BooksController> logger)
    {
        _repository = repository;
        _userManager = userManager;
        _authService = authService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> ViewBooks()
    {
        return View(await _repository.GetBooksAsync());
    }

    [HttpGet]
    public async Task<IActionResult> AddToFavourite(int id)
    {
        var idUser = _userManager.GetUserId(User);
        var user = await _userManager.FindByIdAsync(idUser);
        _logger.LogInformation($"{user.Email}");
        if (user != null)
        {
            var book = await _repository.GetBookAsync(id);
            
            if (book != null)
            {
                var userBookFavourite = new UserBookFavourite
                {
                    UserId = user.Id,
                    BookId = book.Id
                };

                await _repository.AddFavouriteUserBookAsync(userBookFavourite);

                return RedirectToAction("ViewBooks", "Books");
            }
        }

        return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> ViewDetailBook(int id)
    {
        var book = await _repository.GetBookAsync(id);
        return View(book);
    }
}