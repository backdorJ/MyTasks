using Newtonsoft.Json;

namespace FleaMarket.API.Models.Recipe;

public class Us
{
    [JsonProperty("amount")]
    public double Amount { get; set; }
    
    [JsonProperty("unitShort")]
    public string UnitShort { get; set; }
    
    [JsonProperty("unitLong")]
    public string UnitLong { get; set; }
}