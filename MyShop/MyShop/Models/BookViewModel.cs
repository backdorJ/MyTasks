using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyShop.Authorization;

namespace MyShop.Models;

[Table("Books")]
public class BookViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }

    [Required]
    public string PhotoPath { get; set; }

    public ICollection<UserBookFavourite> Users { get; set; }
}