using Src.Models.Users.Infra.Entities;
using Src.Models.Users.Infra.Repositories;

namespace Src.Models.Users.UseCases;

public class ListUsersUseCase 
{ 
  private readonly IUserRepository _usersRepository;
  public ListUsersUseCase(IUserRepository usersRepository)
  {
    _usersRepository = usersRepository;
  }

  public async Task<List<User>> Execute()
  {
    var users = await _usersRepository.ListUsers();
    return users;
  }
}