using Newtonsoft.Json;

namespace FleaMarket.API.Models;

public class BeerModel
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("uid")]
    public string uid { get; set; }
    
    [JsonProperty("brand")]
    public string brand { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("style")]
    public string Style { get; set; }
    
    [JsonProperty("hop")]
    public string Hop { get; set; }
    
    [JsonProperty("yeast")]
    public string Year { get; set; }
    
    [JsonProperty("malts")]
    public string malts { get; set; }
    
    [JsonProperty("ibu")]
    public string ibu { get; set; }
    
    [JsonProperty("alcohol")]
    public string AlcoholProcent { get; set; }
    
    [JsonProperty("blg")]
    public string Graduc { get; set; }
}