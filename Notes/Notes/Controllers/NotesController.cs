using Microsoft.AspNetCore.Mvc;
using Notes.Interfaces;
using Notes.Models;
using Serilog;

namespace Notes.Controllers;

public class NotesController : Controller
{
    private readonly INotesRepository _repository;

    public NotesController(
        INotesRepository repository)
    {
        _repository = repository;
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
        Log.Information("Open [POST] Notes method");
        await _repository.CreateNoteAsync(model);
        return RedirectToAction("Index", "Home");
    }
}