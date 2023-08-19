using Notes.Models;

namespace Notes.Interfaces;

public interface INotesRepository : IDisposable
{
    Task<NotesViewModel> GetNoteByIdAsync(int idNote);
    Task<List<NotesViewModel>> GetAllNoteByUserAsync(string id);
    Task AddNotesByUserAsync(NotesViewModel model, string idUser);
    Task UpdateNoteAsync(NotesViewModel model);
}