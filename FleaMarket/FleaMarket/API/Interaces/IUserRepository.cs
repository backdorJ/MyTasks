using FleaMarket.API.Models.Users;

namespace FleaMarket.API.Interaces;

public interface IUserRepository
{
    Task<List<UserModel>> GetUsersAsync(int amount);
}