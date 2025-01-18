namespace HudleApi.Models;

public class UserModel
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}