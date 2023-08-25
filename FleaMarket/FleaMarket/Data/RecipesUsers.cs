using FleaMarket.API.Models.Recipe;
using FleaMarket.Authoriz;

namespace FleaMarket.Data;

public class RecipesUsers
{
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}