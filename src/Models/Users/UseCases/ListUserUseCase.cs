using Src.Models.Users.Infra.Entities;
using Src.Models.Users.Infra.Repositories;

namespace Src.Models.Users.UseCases;
public class ListUserUseCase 
{
  private readonly IUserRepository _userRepository;
  public ListUserUseCase(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<User> Execute(string id) 
  {
    var user = await _userRepository.ListUserById(id);
    return user;
  }
}