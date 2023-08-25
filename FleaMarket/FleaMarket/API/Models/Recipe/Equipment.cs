using FleaMarket.API.Models.Recipe;
using Newtonsoft.Json;

namespace FleaMarket.API.Interaces.Implementashion;

public class Equipment
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("localizedName")]
    public string LocalizedName { get; set; }
    
    [JsonProperty("image")]
    public string Image { get; set; }
    
    [JsonProperty("temperature")]
    public Temperature Temperature { get; set; }
}