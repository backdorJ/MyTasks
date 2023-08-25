using System.ComponentModel.DataAnnotations.Schema;
using FleaMarket.Data;
using Newtonsoft.Json;

namespace FleaMarket.API.Models.Recipe;

public class Recipe
{
    [NotMapped]
    [JsonProperty("vegetarian")]
    public bool? vegetarian { get; set; }
    
    [NotMapped]
    [JsonProperty("vegan")]
    public bool? vegan { get; set; }
    
    [NotMapped]
    [JsonProperty("glutenFree")]
    public bool? glutenFree { get; set; }
    
    [NotMapped]
    [JsonProperty("dairyFree")]
    public bool? dairyFree { get; set; }
    
    [NotMapped]
    [JsonProperty("veryHealthy")]
    public bool? veryHealthy { get; set; }
    
    [NotMapped]
    [JsonProperty("cheap")]
    public bool? cheap { get; set; }
    
    [NotMapped]
    [JsonProperty("veryPopular")]
    public bool? veryPopular { get; set; }
    
    [NotMapped]
    [JsonProperty("sustainable")]
    public bool? sustainable { get; set; }
    
    [NotMapped]
    [JsonProperty("lowFodmap")]
    public bool? lowFodmap { get; set; }
    
    [NotMapped]
    [JsonProperty("weightWatcherSmartPoints")]
    public int? weightWatcherSmartPoints { get; set; }
    
    [NotMapped]
    [JsonProperty("gaps")]
    public string gaps { get; set; }
    
    [JsonProperty("preparationMinutes")]
    public int? preparationMinutes { get; set; }
    
    [JsonProperty("cookingMinutes")]
    public int? cookingMinutes { get; set; }
    
    [JsonProperty("aggregateLikes")]
    public int? aggregateLikes { get; set; }
    
    [JsonProperty("healthScore")]
    public int? healthScore { get; set; }
    
    [JsonProperty("creditsText")]
    public string? creditsText { get; set; }
    
    [JsonProperty("license")]
    public string? license { get; set; }
    
    [JsonProperty("sourceName")]
    public string? sourceName { get; set; }
    
    [JsonProperty("pricePerServing")]
    public double? pricePerServing { get; set; }
    
    [NotMapped]
    [JsonProperty("extendedIngredients")]
    public List<ExtendedIngredient> extendedIngredients { get; set; }
    
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("title")]
    public string? title { get; set; }
    
    [JsonProperty("readyInMinutes")]
    public int? readyInMinutes { get; set; }
    
    [JsonProperty("servings")]
    public int? servings { get; set; }
    
    [NotMapped]
    [JsonProperty("sourceUrl")]
    public string sourceUrl { get; set; }
    
    [JsonProperty("image")]
    public string? image { get; set; }
    
    [JsonProperty("imageType")]
    public string? imageType { get; set; }
    
    [JsonProperty("summary")]
    public string? summary { get; set; }
    
    [NotMapped]
    [JsonProperty("cuisines")]
    public List<object> cuisines { get; set; }
    
    [NotMapped]
    [JsonProperty("dishTypes")]
    public List<string> dishTypes { get; set; }
    
    [NotMapped]
    [JsonProperty("diets")]
    public List<object> diets { get; set; }
    
    [NotMapped]
    [JsonProperty("occasions")]
    public List<object> occasions { get; set; }
    
    [NotMapped]
    [JsonProperty("instructions")]
    public string instructions { get; set; }
    
    [NotMapped]
    [JsonProperty("analyzedInstructions")]
    public List<AnalyzedInstruction> analyzedInstructions { get; set; }
    
    [NotMapped]
    [JsonProperty("originalId")]
    public object originalId { get; set; }
    
    [NotMapped]
    [JsonProperty("spoonacularSourceUrl")]
    public string spoonacularSourceUrl { get; set; }
    
    [JsonIgnore]
    public ICollection<RecipesUsers> Users { get; set; }
}