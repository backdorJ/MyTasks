using FleaMarket.API.Models.Recipe;

namespace FleaMarket.API.Interaces;

public interface IFoodRepository
{
    Task<AllRecipes> GetAllFoodsAsync(int amount);
    Task<Recipe> GetDetailRecipe(int id);
}