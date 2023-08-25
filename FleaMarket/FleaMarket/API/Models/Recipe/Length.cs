using Newtonsoft.Json;

namespace FleaMarket.API.Models.Recipe;

public class Length
{
    [JsonProperty("Number")]
    public int number { get; set; }
    
    [JsonProperty("Unit")]
    public string unit { get; set; }
}