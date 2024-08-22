using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationCore;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMemoryCache();
        service.AddScoped<ISubscriberService, ApplicationCore.Services.SubscriberService>();
        service.AddScoped<ISubscriberGrpcClient, SubscriberGrpcClient>();

        return service;
    }
}