using Microsoft.Extensions.DependencyInjection;
using ApplicationCore.Interfaces;
using MyHttpClient.Services;

namespace MyHttpClient.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMyHttpClient(this IServiceCollection service)
    {
        service.AddHttpClient<ISubscriberHttpClient, SubscriberHttpService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5029/");
        });
        
        return service;
    }

    // public static IServiceCollection AddSuperGrpc(this IServiceCollection service)
    // {
    //     
    //     return service;
    // }
}