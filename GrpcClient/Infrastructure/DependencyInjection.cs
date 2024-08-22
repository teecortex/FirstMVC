using ApplicationCore.Interfaces;
using GrpcClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GrpcClient.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMyGrpcClient(this IServiceCollection service)
    {
        service.AddGrpcClient<SubscriberService.SubscriberServiceClient>(options =>
        {
            options.Address = new Uri("http://localhost:5037");
        });

        return service;
    }

    public static IServiceCollection AddSubscriberGrpcService(this IServiceCollection service)
    {
        service.AddScoped<ISubscriberGrpcService, SubscriberGrpcService>();

        return service;
    }
}