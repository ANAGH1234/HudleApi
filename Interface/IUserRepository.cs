using HudleApi.Models;

namespace HudleApi.Interface;

public interface IUserRepository
{
    Task<UserModel> GetUserByEmailAndPassword(string email, string password);
    Task<UserModel> GetUserByEmail(string email);
    Task CreateUser(UserModel user);
}