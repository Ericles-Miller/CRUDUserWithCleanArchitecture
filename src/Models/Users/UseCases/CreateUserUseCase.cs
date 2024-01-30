using Src.Models.Users.Infra.Entities;
using Src.Models.Users.Infra.Repositories;
namespace Src.Models.Users.UseCases;
public class CreateUserUseCase 
{
  private IUserRepository _usersRepository;
  public CreateUserUseCase(IUserRepository userRepository)
  { _usersRepository = userRepository; }

  public async Task Execute(User user)
  {
    var findUser = await _usersRepository.UserAlreadyExists(user.Id);
    if(findUser) {
      throw new Exception("User already exists!");
    }

    await _usersRepository.Create(user);
  }
}

