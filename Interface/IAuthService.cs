using HudleApi.Models;

namespace HudleApi.Interface;

public interface IAuthService
{
    Task<UserModel> Authenticate(string email, string password);
    Task Register(string email, string password);
}