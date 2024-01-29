using Src.Models.Users.Infra.Repositories;

namespace Src.Config.Container;

public static class DependencyInjection
{
  public static IServiceCollection AddRepositories(this IServiceCollection services)
  {
    services.AddScoped<IUserRepository, UserRepositories>();
    return services;
  }
}