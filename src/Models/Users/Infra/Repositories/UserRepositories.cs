
using Microsoft.EntityFrameworkCore;
using Src.Configs.DataBase;
using Src.Models.Users.Infra.DTOs;
using Src.Models.Users.Infra.Entities;
using Src.Models.Users.Infra.Repositories;

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

  public async Task<bool> UserAlreadyExists(string id)
  {
    var user = await _context.Users.AnyAsync(user => user.Id == id);
    return user;
  }
}