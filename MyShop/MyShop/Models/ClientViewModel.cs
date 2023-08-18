namespace MyShop.Models;

public class ClientViewModel
{
    public int Id { get; set; }
    public ICollection<BookViewModel> Books { get; set; }
}