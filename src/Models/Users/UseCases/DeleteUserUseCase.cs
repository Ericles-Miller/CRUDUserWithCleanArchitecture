using Src.Models.Users.Infra.Repositories;

namespace Src.Models.Users.UseCases;


public class DeleteUserUseCase {
  private readonly IUserRepository _userRepository;
  public DeleteUserUseCase(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task Execute(string id) 
  { 
    var findUser = await _userRepository.ListUserById(id);
    if(findUser == null) {
      throw new Exception("userId does not exists!");
    }
    
    await _userRepository.Delete(findUser);
  }
}