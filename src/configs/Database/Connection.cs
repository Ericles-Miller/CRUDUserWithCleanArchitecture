using Microsoft.EntityFrameworkCore;
using src.Models.Users.infra.Entities;

namespace src.configs.DataBase
{
  public class Connection : DbContext {
    public DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => 
      options.UseSqlite("DataSource=app.db;Cache=Shared");
    
  }
}