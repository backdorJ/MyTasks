using Newtonsoft.Json;

namespace FleaMarket.API.Models.Recipe;

public class AllRecipes
{
    [JsonProperty("recipes")]
    public List<Recipe> Recipes { get; set; }
}