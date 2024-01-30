using Src.Models.Users.Infra.Entities;

namespace Src.Models.Users.Infra.Repositories;

public interface IUserRepository 
{
  Task Create(User user);
  Task Delete(User user);
  Task<User> ListUserById(string id);
  Task<List<User>> ListUsers();
  Task<User> UpdateUser(string id, User user);
  Task<bool> UserAlreadyExists(string id);
}