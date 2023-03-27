using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomApplicationExtensions(this IServiceCollection services)
    {
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IOwnerService, OwnerService>();
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<IInfringementService, InfringementService>();

        return services;
    }
}
