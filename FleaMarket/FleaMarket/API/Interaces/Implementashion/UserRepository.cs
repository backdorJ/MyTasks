using FleaMarket.API.Models.Users;
using Newtonsoft.Json;

namespace FleaMarket.API.Interaces.Implementashion;

public class UserRepository : IUserRepository
{
    private readonly HttpClient _client;

    public UserRepository(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<List<UserModel>> GetUsersAsync(int amount)
    {
        var response = await _client.GetAsync($"users?response_type=json&size={amount}");
        if (!response.IsSuccessStatusCode)
            return new List<UserModel>();
        return JsonConvert.DeserializeObject<List<UserModel>>(await response.Content.ReadAsStringAsync());
    }
}