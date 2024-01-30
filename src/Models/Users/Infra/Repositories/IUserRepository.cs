using Src.Models.Users.Infra.DTOs;
using Src.Models.Users.Infra.Entities;

namespace Src.Models.Users.Infra.Repositories;

public interface IUserRepository {
  Task Create(User user);
  Task<bool> UserAlreadyExists(string id);
  Task<List<User>> ListUsers();
}