using Microsoft.AspNetCore.Mvc;
using Src.Configs.DataBase;
using Src.Models.Users.Infra.Entities;
using Src.Models.Users.UseCases;

namespace Src.Controllers;

  [Route("/users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly CreateUserUseCase _createUserUseCase;
    private readonly ListUsersUseCase _listUsersUseCase;
    private readonly ListUserUseCase _listUserUseCase;
    private readonly UpdateUserUseCase _updateUserUseCase;
    
    public UsersController(
      CreateUserUseCase createUserUseCase,
      ListUsersUseCase listUsersUseCase,
      ListUserUseCase listUserUseCase,
      UpdateUserUseCase updateUserUseCase
    ){
      _createUserUseCase = createUserUseCase;
      _listUsersUseCase = listUsersUseCase;
      _listUserUseCase = listUserUseCase;
      _updateUserUseCase = updateUserUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    { 
      var users = await _listUsersUseCase.Execute();
      return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user) 
    {
      await _createUserUseCase.Execute(user);
      return Ok(user);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    { 
      var user = await _listUserUseCase.Execute(id);
      return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] User user) 
    { 
      var updateUser = await _updateUserUseCase.Execute(id, user);
      return Ok(updateUser);
    }

    [HttpDelete("{id}")]
    public User Delete(string id, [FromServices] AppDbContext context)
    { 
      var findUser = context.Users.FirstOrDefault(user => user.Id == id);
      if(findUser == null) {
        return null;
      }

      context.Users.Remove(findUser);
      context.SaveChanges();

      return findUser;
    }
  }
