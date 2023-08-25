namespace FleaMarket.API.Models.Users;

public class UserModel
{
    public int id { get; set; }
    public string uid { get; set; }
    public string password { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string avatar { get; set; }
    public string gender { get; set; }
    public string phone_number { get; set; }
    public string social_insurance_number { get; set; }
    public string date_of_birth { get; set; }
    public Employment employment { get; set; }
    public Address address { get; set; }
    public CreditCard credit_card { get; set; }
    public Subscription subscription { get; set; }
}