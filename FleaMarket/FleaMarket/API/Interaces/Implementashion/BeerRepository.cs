using FleaMarket.API.Models;
using Newtonsoft.Json;

namespace FleaMarket.API.Interaces.Implementashion;

public class BeerRepository : IBeerRepository
{
    private readonly HttpClient _client;

    public BeerRepository(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<BeerModel>?> GetBeersAsync(int amount)
    {
        var response = await _client.GetAsync($"beers?response_type=json&size={amount}");
        Console.WriteLine($"text: {await response.Content.ReadAsStringAsync()}");
        return response.IsSuccessStatusCode ?
            JsonConvert.DeserializeObject<List<BeerModel>>(await response.Content.ReadAsStringAsync())
            : new List<BeerModel>();
    }
}