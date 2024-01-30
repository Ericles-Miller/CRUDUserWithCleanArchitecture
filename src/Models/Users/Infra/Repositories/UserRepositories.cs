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

  public async Task Delete(User user)
  {
    _context.Remove(user);
    await _context.SaveChangesAsync();

  }

  public async Task<User> ListUserById(string id)
  {
    var user = await _context.Users.FindAsync(id);
    return user;
  }

  async public Task<List<User>> ListUsers()
  {
    var users = await _context.Users.ToListAsync();
    return users;
  }

  public async Task<User> UpdateUser(string id, User user)
  {
    var findUser = await  _context.Users.FirstOrDefaultAsync(user => user.Id == id);
    if(findUser == null) 
    {
      return null;
    }

    findUser.Email = user.Email;
    findUser.Name = user.Name;
    findUser.UserName = user.UserName;

    _context.Users.Update(findUser);
    await _context.SaveChangesAsync();

    return findUser;
  }

  public async Task<bool> UserAlreadyExists(string id)
  {
    var user = await _context.Users.AnyAsync(user => user.Id == id);
    return user;
  }
}