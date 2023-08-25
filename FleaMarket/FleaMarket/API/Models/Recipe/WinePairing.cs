using Newtonsoft.Json;

namespace FleaMarket.API.Models.Recipe;

public class WinePairing
{
    [JsonProperty("pairedWines")]
    public List<object> PairedWines { get; set; }
    
    [JsonProperty("pairingText")]
    public string PairingText { get; set; }
    
    [JsonProperty("productMatches")]
    public List<object> ProductMatches { get; set; }
}