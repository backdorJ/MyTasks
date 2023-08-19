using Microsoft.EntityFrameworkCore;
using Notes.Data;
using Notes.Interfaces;
using Notes.Models;

namespace Notes.Implementashions;

public class SQLNotesRepository : INotesRepository
{
    private readonly ApplicationDbContext _context;

    public SQLNotesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<NotesViewModel> GetNoteByIdAsync(int idNote)
    {
        return await _context
            .Notes
            .FirstOrDefaultAsync(x => x.Id == idNote);
    }

    public async Task<List<NotesViewModel>> GetAllNoteByUserAsync(string id)
    {
        return await _context
            .Notes
            .Where(x => x.ApplicationUserId == id)
            .ToListAsync();
    }

    public async Task AddNotesByUserAsync(NotesViewModel model, string idUser)
    {
        model.ApplicationUserId = idUser;
        await _context.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateNoteAsync(NotesViewModel model)
    {
        var oldNote = await _context
            .Notes
            .FirstOrDefaultAsync(x => x.Id == model.Id);
        oldNote.Color = model.Color;
        oldNote.Title = model.Title;
        oldNote.LastUpdate = model.LastUpdate;
        oldNote.Description = model.Description;
        _context.Notes.Update(oldNote);
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}