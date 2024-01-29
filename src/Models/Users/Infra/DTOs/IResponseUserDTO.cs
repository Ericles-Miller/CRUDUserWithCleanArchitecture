namespace Src.Models.Users.Infra.DTOs;

public interface IResponseUserDTO {
  string name { get; set; }
  string email { get; set; }
  string password { get; set; }
  DateTime createdAt {get; set;}
}