using Microsoft.EntityFrameworkCore;
using MyShop.Authorization;
using MyShop.Data;
using MyShop.Interfaces;
using MyShop.Models;

namespace MyShop.Implementashions;

public class PostgressBooksRepository : IBooksRepository
{
    private readonly ApplicationDbContext _context;

    public PostgressBooksRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookViewModel>> GetBooksAsync()
        => await _context.BookViewModels.ToListAsync();
    

    public async Task<BookViewModel> GetBookAsync(int id)
        => await _context.BookViewModels.FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddFavouriteUserBookAsync(UserBookFavourite userBookFavourite)
    {
        _context.UserBookFavourites.Add(userBookFavourite);
        await _context.SaveChangesAsync();
    }

    public async Task<List<BookViewModel>> GetBooksForClientAsync(string idClient)
    {
        var books = await _context
            .UserBookFavourites
            .Where(x => x.UserId == idClient)
            .Select(x => x.Book)
            .ToListAsync();
        return books;
    }

    public async Task DeleteFavouriteBookAsync(string idClient, int idBook)
    {
        var favouriteBook = await _context
            .UserBookFavourites
            .Where(x => x.BookId == idBook && x.UserId == idClient)
            .FirstOrDefaultAsync();
        
        if (favouriteBook != null)
        {
            _context.UserBookFavourites.Remove(favouriteBook);   
        }
        await _context.SaveChangesAsync();
    }

    public async Task<List<BookViewModel>> GetBookAboutNumber(int count)
    {
        var allCount = _context.BookViewModels.Count();
        if (count > allCount) count -= allCount;
        return await _context.BookViewModels.Take(count).ToListAsync();
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