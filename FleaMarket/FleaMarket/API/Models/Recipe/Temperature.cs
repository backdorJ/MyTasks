using Newtonsoft.Json;

namespace FleaMarket.API.Models.Recipe;

public class Temperature
{
    [JsonProperty("number")]
    public double Number { get; set; }
    
    [JsonProperty("unit")]
    public string Unit { get; set; }
}