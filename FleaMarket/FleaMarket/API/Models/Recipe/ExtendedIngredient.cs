using Newtonsoft.Json;

namespace FleaMarket.API.Models.Recipe;

public class ExtendedIngredient
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("aisle")]
    public string Aisle { get; set; }
    
    [JsonProperty("image")]
    public string Image { get; set; }
    
    [JsonProperty("consistency")]
    public string Consistency { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("nameClean")]
    public string NameClean { get; set; }
    
    [JsonProperty("original")]
    public string Original { get; set; }
    
    [JsonProperty("originalName")]
    public string OriginalName { get; set; }
    
    [JsonProperty("amount")]
    public double Amount { get; set; }
    
    [JsonProperty("unit")]
    public string Unit { get; set; }
    
    [JsonProperty("meta")]
    public List<string> Meta { get; set; }
    
    [JsonProperty("measures")]
    public Measures Measures { get; set; }
}