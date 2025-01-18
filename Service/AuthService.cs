using HudleApi.Interface;
using HudleApi.Models;

namespace HudleApi.Service;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> Authenticate(string email, string password)
    {
        return await _userRepository.GetUserByEmailAndPassword(email, password);
    }

    public async Task Register(string email, string password)
    {
        var existingUser = await _userRepository.GetUserByEmail(email);
        if (existingUser != null)
        {
            throw new System.Exception("User already exists.");
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new UserModel
        {
            Email = email,
            PasswordHash = hashedPassword,
            Role = "User"
        };

        await _userRepository.CreateUser(user);
    }
}