using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Authorize;
using Notes.Interfaces;
using Notes.Models;
using Serilog;

namespace Notes.Controllers;

public class NotesController : Controller
{
    private readonly INotesRepository _repository;
    private readonly UserManager<ApplicationUser> _userManager;

    public NotesController(
        INotesRepository repository,
        UserManager<ApplicationUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> AddNotes()
    {
        Log.Information("Open [GET] Notes method ");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddNotes(NotesViewModel model)
    {
        var userId = _userManager.GetUserId(User);
        Log.Information("Open [POST] Notes method");
        if (model.Title == null)
        {
            ViewBag.Failed = true;
            return View();
        }

        await _repository.AddNotesByUserAsync(model, userId);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> DetailNote(int id)
    {
        return View(await _repository.GetNoteByIdAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> EditeNote(int id)
    {
        return View(await _repository.GetNoteByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> EditeNote(NotesViewModel model)
    {
        await _repository.UpdateNoteAsync(model);
        ViewBag.IsSuccess = true;
        return View(model);
    }
}