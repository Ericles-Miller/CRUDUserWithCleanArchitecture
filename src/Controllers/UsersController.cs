using Microsoft.AspNetCore.Mvc;
using src.configs.DataBase;
using src.Models.Users.infra.Entities;
namespace src.Controllers;

  [Route("/users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    [HttpGet]
    public List<Users> Get([FromServices] AppDbContext context)
    { 
      return context.Users.ToList();
    }

    [HttpPost]
    public Users Post([FromBody] Users user, [FromServices] AppDbContext context) 
    {
      context.Users.Add(user);
      context.SaveChanges();

      return user;
    }

    [HttpGet("{id}")]
    public Users GetById(string id, [FromServices] AppDbContext context)
    { 
      return context.Users.FirstOrDefault(user => user.Id == id);
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
