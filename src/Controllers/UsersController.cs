using Microsoft.AspNetCore.Mvc;
using src.configs.DataBase;
using src.Models.Users.infra.Entities;
namespace src.Controllers;

  [ApiController]
  [Route("/users")]
  public class UsersController : ControllerBase
  {
    [HttpGet]
    public List<Users> Get([FromServices] AppDbContext context)
    { 
      return context.Users.ToList();
    }

    [HttpPost]
    public Users Post(Users user, [FromServices] AppDbContext context) 
    {
      context.Users.Add(user);
      context.SaveChanges();

      return user;
    }
  }
