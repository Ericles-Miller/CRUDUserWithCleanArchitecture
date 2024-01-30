using Src.Models.Users.Infra.Repositories;
using Src.Models.Users.UseCases;

namespace Src.Config.Container;

public static class DependencyInjection
{
  public static IServiceCollection AddRepositories(this IServiceCollection services)
  {
    services.AddScoped<IUserRepository, UserRepositories>();
    return services;
  }

  public static IServiceCollection AddUseCases(this IServiceCollection services)
  {
    services.AddScoped<CreateUserUseCase>();
    services.AddScoped<DeleteUserUseCase>();
    services.AddScoped<ListUserUseCase>();
    services.AddScoped<ListUsersUseCase>();
    services.AddScoped<UpdateUserUseCase>();
    return services;
  }
}