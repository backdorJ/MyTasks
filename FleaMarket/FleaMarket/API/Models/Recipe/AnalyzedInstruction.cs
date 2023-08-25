using Newtonsoft.Json;

namespace FleaMarket.API.Models.Recipe;

public class AnalyzedInstruction
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("steps")]
    public List<Step> Steps { get; set; }
}