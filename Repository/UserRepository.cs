using HudleApi.Data;
using HudleApi.Interface;
using HudleApi.Models;

namespace HudleApi.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserModel> GetUserByEmailAndPassword(string email, string password)
    {
        var user = await _context.Users.FindAsync(email);
        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return user;
        }
        return null;
    }

    public async Task<UserModel> GetUserByEmail(string email)
    {
        return await _context.Users.FindAsync(email);
    }

    public async Task CreateUser(UserModel user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

}