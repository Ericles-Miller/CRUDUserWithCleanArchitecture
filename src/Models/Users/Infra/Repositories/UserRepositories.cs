
using Microsoft.EntityFrameworkCore;
using Src.Configs.DataBase;
using Src.Models.Users.Infra.Entities;

namespace Src.Models.Users.Infra.Repositories;
public class UserRepositories : IUserRepository
{ 
  private readonly AppDbContext _context;

  public UserRepositories(AppDbContext context)
  {
    _context = context;
  }

    public async Task Create(User user )
  {
    await  _context.Users.AddAsync(user);
    await  _context.SaveChangesAsync();
  }

    async public Task<List<User>> ListUsers()
    {
      var users = await _context.Users.ToListAsync();

      return users;
    }

    public async Task<bool> UserAlreadyExists(string id)
  {
    var user = await _context.Users.AnyAsync(user => user.Id == id);
    return user;
  }
}