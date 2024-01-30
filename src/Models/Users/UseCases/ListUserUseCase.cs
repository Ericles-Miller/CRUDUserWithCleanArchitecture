using Src.Models.Users.Infra.Entities;
using Src.Models.Users.Infra.Repositories;

namespace Src.Models.Users.UseCases;

public class ListUserUseCase 
{
    private IUserRepository _usersRepository;

    public ListUserUseCase(IUserRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<List<User>> Execute()
    {
      var users = await _usersRepository.ListUsers();
      return users;
    }
}