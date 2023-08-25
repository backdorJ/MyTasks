namespace FleaMarket.API.Models.Users;


public class Subscription
{
    public string plan { get; set; }
    public string status { get; set; }
    public string payment_method { get; set; }
    public string term { get; set; }
}