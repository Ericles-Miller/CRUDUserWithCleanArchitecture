using Microsoft.EntityFrameworkCore;
using src.Models.Users.infra.Entities;

namespace src.configs.DataBase
{
  public class AppDbContext : DbContext 
  {
    // import entity class
    public DbSet<Users> Users { get; set; }
    
    // connection string
    protected override void OnConfiguring(DbContextOptionsBuilder options) => 
      options.UseSqlite("DataSource=app.db;Cache=Shared");
    
  }
}