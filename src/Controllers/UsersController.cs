using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.configs.DataBase;
using src.Models.Users.infra.Entities;
namespace src.Controllers;

  [Route("/users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    [HttpGet]
    public async Task<IActionResult> Get([FromServices] AppDbContext context)
    { 
     var users = await context.Users.ToListAsync();

     return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Users user, [FromServices] AppDbContext context) 
    {
      await context.Users.AddAsync(user);
      await context.SaveChangesAsync();

      return Ok(user);
    }

    [HttpGet("findUser/{id}")]
    public async Task<IActionResult> GetById(string id, [FromServices] AppDbContext context)
    { 
      var user = await context.Users.FirstOrDefaultAsync(user => user.Id == id);

      return Ok(user);
    }

    [HttpPut("{id}")]
    public Users Put(string id, [FromBody] Users user, [FromServices] AppDbContext context) 
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
    public Users Delete(string id, [FromServices] AppDbContext context)
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
