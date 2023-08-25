using FleaMarket.API.Models.Recipe;
using Newtonsoft.Json;
using Serilog;

namespace FleaMarket.API.Interaces.Implementashion;

public class FoodRepository : IFoodRepository
{
    private readonly HttpClient _client;

    public FoodRepository(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<AllRecipes> GetAllFoodsAsync(int amount)
    {
        var response = await _client.GetAsync($"recipes/random?number={amount}");
        if (response.IsSuccessStatusCode)
        {
            Log.Information("Response is successfully");
            var recipes = JsonConvert.DeserializeObject<AllRecipes>(await response.Content.ReadAsStringAsync());
            Log.Information(await response.Content.ReadAsStringAsync());
            return recipes;
        }
        
        Log.Error("Maybe you dont authorize");
        return new AllRecipes();
    }

    public async Task<Recipe> GetDetailRecipe(int id)
    {
        var response = await _client.GetAsync($"https://api.spoonacular.com/recipes/{id}/information");
        if (response.IsSuccessStatusCode)
        {
            Log.Information("Response is successfully");
            var detailRecipe = JsonConvert.DeserializeObject<Recipe>(await response.Content.ReadAsStringAsync());
            return detailRecipe;
        }

        return new Recipe();
    }
}