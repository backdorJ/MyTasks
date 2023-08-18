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

    public async Task CreateNoteAsync(NotesViewModel model)
    {
        await _context.Notes.AddAsync(model);
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