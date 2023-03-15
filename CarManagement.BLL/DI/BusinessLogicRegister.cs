using CarManagement.BLL.Interfaces;
using CarManagement.BLL.Services;
using CarManagement.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarManagement.BLL.DI;

public static class BusinessLogicRegister
{
    public static void AddBusinessLogicLayer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDataAccessLayer(configuration);
        services.AddCars();
        services.AddUsers();
    }

    private static void AddCars(
        this IServiceCollection services)
    {
        services.AddScoped<ICarService, CarService>();
    }

    private static void AddUsers(
        this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}
