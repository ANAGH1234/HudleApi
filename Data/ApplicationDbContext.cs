using HudleApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HudleApi.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(u => u.Email);
            entity.Property(u => u.PasswordHash).IsRequired();
            entity.Property(u => u.Role).IsRequired();
        });
    }
}