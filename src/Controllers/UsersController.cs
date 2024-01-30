using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Src.Configs.DataBase;
using Src.Models.Users.Infra.Entities;
using Src.Models.Users.UseCases;

namespace Src.Controllers;

  [Route("/users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly CreateUserUseCase _createUserUseCase;
    private readonly ListUserUseCase _listUserUseCase;
    
    public UsersController(CreateUserUseCase createUserUseCase, ListUserUseCase listUserUseCase)
    {
      _createUserUseCase = createUserUseCase;
      _listUserUseCase = listUserUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    { 
      var users = await _listUserUseCase.Execute();
      return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user) 
    {
      await _createUserUseCase.Execute(user);
      return Ok(user);
    }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById(string id, [FromServices] AppDbContext context)
    // { 
      
    //   return Ok(user);
    // }


    [HttpPut("{id}")]
    public User Put(string id, [FromBody] User user, [FromServices] AppDbContext context) 
    { 
      var findUser = context.Users.FirstOrDefault(user => user.Id == id);
      if(findUser == null) {
        return null;
      }

      findUser.Email = user.Email;
      findUser.Name = user.Name;
      findUser.UserName = user.UserName;

      context.Users.Update(findUser);
      context.SaveChanges();

      return user;
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
