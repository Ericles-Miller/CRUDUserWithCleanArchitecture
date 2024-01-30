using Src.Models.Users.Infra.Entities;
using Src.Models.Users.Infra.Repositories;

namespace Src.Models.Users.UseCases;

public class UpdateUserUseCase 
{
  private readonly IUserRepository _usersRepository;
  public UpdateUserUseCase(IUserRepository usersRepository)
  {
    _usersRepository = usersRepository;
  }

  public async Task<User> Execute(string id, User user) 
  {
    var findUser = await _usersRepository.UserAlreadyExists(id);
    if(!findUser) {
      throw new Exception("UserID does not exists");
    }

    var newUserUpdate = await _usersRepository.UpdateUser(id, user);

    return newUserUpdate;

  }
}