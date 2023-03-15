using CarManagement.DAL.Interfaces;
using CarManagement.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarManagement.DAL.DI;

public static class DataAccessRegister
{
    public static void AddDataAccessLayer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCarRepository();
        services.AddUserRepository();
        services.AddConnectionString(configuration);
    }

    private static void AddCarRepository(this IServiceCollection services)
    {
        services.AddScoped<ICarRepository, CarRepository>();
    }

    private static void AddUserRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void AddConnectionString(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<IConnectionString, ConnectionString>();
        services.AddSingleton(configuration);
    }
}
