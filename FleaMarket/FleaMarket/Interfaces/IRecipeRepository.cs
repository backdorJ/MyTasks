using FleaMarket.API.Models.Recipe;
using FleaMarket.Data;

namespace FleaMarket.Interfaces;

public interface IRecipeRepository : IDisposable
{
    Task AddRecipeInFavouriteAsync(RecipesUsers model);
    Task AddedInDatabaseRecipeAsync(Recipe recipe);
    
    Task<List<Recipe>> GetAllRecipesByIdUserAsync(string userId);
    Task<bool> DeleteRecipeByIdUserAsync(int recipeId, string userId);
    Task DeleteRecipeInDatabaseAsync(int id);
}