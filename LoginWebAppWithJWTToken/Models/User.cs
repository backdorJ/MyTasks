using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LoginWebAppWithJWTToken.Models;

public class User
{
    [Required]
    [JsonIgnore]
    public int Id { get; set; }
    [Required]
    [JsonProperty("email")]
    public string Email { get; set; }
    [Required]
    [JsonProperty("password")]
    public string Password { get; set; }
}