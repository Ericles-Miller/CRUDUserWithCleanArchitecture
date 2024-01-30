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
    private readonly DeleteUserUseCase _deleteUserUseCase;

    public UsersController(
      CreateUserUseCase createUserUseCase,
      DeleteUserUseCase deleteUserUseCase,
      ListUsersUseCase listUsersUseCase,
      ListUserUseCase listUserUseCase,
      UpdateUserUseCase updateUserUseCase
    ){
      _createUserUseCase = createUserUseCase;
      _listUsersUseCase = listUsersUseCase;
      _listUserUseCase = listUserUseCase;
      _updateUserUseCase = updateUserUseCase;
      _deleteUserUseCase = deleteUserUseCase;
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
    public async  Task<IActionResult> Delete(string id)
    { 
      await _deleteUserUseCase.Execute(id);
      return Ok();
    }
  }
