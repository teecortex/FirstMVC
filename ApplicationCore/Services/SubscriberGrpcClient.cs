using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace ApplicationCore.Services;

public class SubscriberGrpcClient : ISubscriberGrpcClient
{
    private readonly ISubscriberGrpcService _service;
    private readonly IMemoryCache _cache;

    public SubscriberGrpcClient(ISubscriberGrpcService service, IMemoryCache cache)
    {
        _service = service;
        _cache = cache;
    }

    public async Task<Subscriber[]?> GetSubscribers()
    {
        return await _cache.GetOrCreateAsync<Subscriber[]?>("Subs", async entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(3));
            var subs = await _service.GetSubscribers();

            return subs;
        });
    }

    public async Task<Subscriber?> GetSubscriber(int id)
    {
        Subscriber? sub = null;

        if (!_cache.TryGetValue("Subs", out Subscriber[]? subs))
        {
            sub = await _service.GetSubscriber(id);
        }
        else
        {
            sub = subs.FirstOrDefault(x => x.Id == id);
        }

        return sub;
    }
}