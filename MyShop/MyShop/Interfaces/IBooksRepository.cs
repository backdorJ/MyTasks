using MyShop.Authorization;
using MyShop.Models;

namespace MyShop.Interfaces;

public interface IBooksRepository : IDisposable
{
    Task<List<BookViewModel>> GetBooksAsync();
    Task<BookViewModel> GetBookAsync(int id);
    Task AddFavouriteUserBookAsync(UserBookFavourite userBookFavourite);

    Task<List<BookViewModel>> GetBooksForClientAsync(string idClient);
    Task DeleteFavouriteBookAsync(string idClient, int idBook);

    Task<List<BookViewModel>> GetBookAboutNumber(int count);
}