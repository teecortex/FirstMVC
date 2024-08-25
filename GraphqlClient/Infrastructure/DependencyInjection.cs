using ApplicationCore.Interfaces;
using GraphqlClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GraphqlClient.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMyGraphQlClient(this IServiceCollection service)
    {
        service.AddGraphqlClient().ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5029/graphql");
        });
        // service.AddScoped<IGraphqlClient, GraphqlClient>();
        
        
        return service;
    }
    

    public static IServiceCollection AddSubscriberGraphqlService(this IServiceCollection service)
    {
        service.AddScoped<ISubscriberGraphqlService, SubscriberGraphqlService>();

        return service;
    }
}