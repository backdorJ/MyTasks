using Newtonsoft.Json;

namespace FleaMarket.API.Models.Recipe;

public class Measures
{
    [JsonProperty("us")]
    public Us Us { get; set; }
    
    [JsonProperty("metric")]
    public Metric Metric { get; set; }
}