using System.Net.Http.Json;
using SimpleWebAPI.Models;

class Program
{
    private static HttpClient _client = new HttpClient();
    private static string _localHost = "https://localhost:7208";
    private async static Task Main()
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        var user = await GetUser(new Guid("1ba0cdcc-7186-43f6-9ffb-361683ac7811"), handler);
        Console.WriteLine($"Name: {user.Name} Age: {user.Age} Id: {user.Id}");
        await AddUser(new User{Name = "Liza", Age = 19},handler);
    }

    private static async Task<User> GetUser(Guid id, HttpClientHandler handler)
    {
        _client = new HttpClient(handler);
        using var response = await _client.GetAsync($"{_localHost}/users/{id}");
        return await response.Content.ReadFromJsonAsync<User>();
    }
    
    private static async Task<List<User>> GetUsers(HttpClientHandler handler)
    { 
        _client = new HttpClient(handler);
        var response = await _client.GetAsync($"{_localHost}/users");
        var listUsers = await response.Content.ReadFromJsonAsync<List<User>>();
        return listUsers;
    }
    
    private static async Task AddUser(User user,HttpClientHandler handler)
    {
        _client = new HttpClient(handler);
        var response = await _client.PostAsJsonAsync($"{_localHost}/users", user);
        Console.WriteLine(response.StatusCode);
    }
}