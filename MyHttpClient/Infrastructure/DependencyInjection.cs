using Microsoft.Extensions.DependencyInjection;
using MyHttpClient.Interfaces;
using MyHttpClient.Services;

namespace MyHttpClient.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddHttpContext(this IServiceCollection service)
    {
        service.AddHttpClient<ISubscriberService, SubscriberService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5029/");
        });
        return service;
    }
}