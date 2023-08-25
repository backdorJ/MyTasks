using Newtonsoft.Json;

namespace FleaMarket.API.Models.Recipe;

public class Ingredient
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("localizedName")]
    public string LocalizedName { get; set; }
    
    [JsonProperty("image")]
    public string Image { get; set; }
}