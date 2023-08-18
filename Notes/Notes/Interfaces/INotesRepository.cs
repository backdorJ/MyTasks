using Notes.Models;

namespace Notes.Interfaces;

public interface INotesRepository : IDisposable
{
    Task CreateNoteAsync(NotesViewModel model);
}