using Microsoft.EntityFrameworkCore;
using Src.Models.Users.Infra.Entities;

namespace Src.Configs.DataBase
{
  public class AppDbContext : DbContext 
  {
    // import entity class
    public DbSet<User> Users { get; set; }
    
    // connection string
    protected override void OnConfiguring(DbContextOptionsBuilder options) => 
      options.UseSqlite("DataSource=app.db;Cache=Shared");
  }
}