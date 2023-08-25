using FleaMarket.API.Models.Recipe;
using FleaMarket.Data;
using FleaMarket.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FleaMarket.Implentashions;

public class SQLRecipeRepository : IRecipeRepository
{
    private readonly ApplicationDbContext _context;

    public SQLRecipeRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    

    private bool _disposed = false;
    
    public void Dispose()
    {
        Dispose(true);
    }

    public async Task AddRecipeInFavouriteAsync(RecipesUsers model)
    {
        await _context.RecipesUsers.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task AddedInDatabaseRecipeAsync(Recipe recipe)
    {
        await _context.Recipes.AddAsync(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Recipe>> GetAllRecipesByIdUserAsync(string userId)
    {
        return await _context.RecipesUsers.Where(x => x.UserId == userId)
            .Select(x => x.Recipe).ToListAsync();
    }

    public async Task<bool> DeleteRecipeByIdUserAsync(int recipeId, string userId)
    {
        var model = await _context
            .RecipesUsers
            .Where(x => x.UserId == userId && x.RecipeId == recipeId)
            .FirstOrDefaultAsync();
        _context.Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteRecipeInDatabaseAsync(int id)
    {
        var recipe = await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                
            }

            _disposed = true;
        }
    }
}