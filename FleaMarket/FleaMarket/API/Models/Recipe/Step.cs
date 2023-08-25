using FleaMarket.API.Interaces.Implementashion;
using Newtonsoft.Json;

namespace FleaMarket.API.Models.Recipe;

public class Step
{
    [JsonProperty("number")]
    public int Number { get; set; }
    
    [JsonProperty("step")]
    public string Steps { get; set; }
    
    [JsonProperty("ingredients")]
    public List<Ingredient> Ingredients { get; set; }
    
    [JsonProperty("equipment")]
    public List<Equipment> Equipment { get; set; }
    
    [JsonProperty("length")]
    public Length Length { get; set; }
}