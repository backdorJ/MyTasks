using FleaMarket.API.Models;

namespace FleaMarket.API.Interaces;

public interface IBeerRepository
{
    Task<List<BeerModel>?> GetBeersAsync(int amount);
}