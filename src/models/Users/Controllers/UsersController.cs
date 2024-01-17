using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace src.Models.Users.Controllers
{
  class UsersController : ControllerBase
  {
    [HttpGet]
    [Route("/response")]
    public string Handle() {
      return "response router";
    }
  }
}