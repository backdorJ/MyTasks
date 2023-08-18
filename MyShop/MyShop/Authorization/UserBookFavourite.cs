using System.ComponentModel.DataAnnotations.Schema;
using MyShop.Models;

namespace MyShop.Authorization;

[Table("UserBooksFavourites")]
public class UserBookFavourite
{
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    public int BookId { get; set; }
    public BookViewModel Book { get; set; }
}