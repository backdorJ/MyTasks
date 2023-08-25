namespace FleaMarket.API.Models.Users;

public class Address
{
    public string city { get; set; }
    public string street_name { get; set; }
    public string street_address { get; set; }
    public string zip_code { get; set; }
    public string state { get; set; }
    public string country { get; set; }
    public Coordinates coordinates { get; set; }
}