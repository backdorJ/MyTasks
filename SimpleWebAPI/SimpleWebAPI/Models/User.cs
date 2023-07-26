using System.ComponentModel.DataAnnotations;

namespace SimpleWebAPI.Models;

public class User
{
    [Required]
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Age { get; set; }
}