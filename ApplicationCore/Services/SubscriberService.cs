using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.Extensions.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace ApplicationCore.Services;

public class SubscriberService : ISubscriberService
{
    private readonly IMemoryCache _cache;
    private readonly ISubscriberHttpClient _client;

    public SubscriberService(IMemoryCache cache, ISubscriberHttpClient client)
    {
        _client = client;
        _cache = cache;
    }

    public async Task<Subscriber[]?> GetSubscribers(CancellationToken token)
    {
        return await _cache.GetOrCreateAsync<Subscriber[]?>("Subs", async entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(3));
            var subs = await _client.GetSubscribers(token);
            return subs;
        });
    }

    public async Task<Subscriber?> GetSubscriber(int id, CancellationToken token)
    {
        Subscriber? sub = null;
        
        if (!_cache.TryGetValue("Subs", out Subscriber[]? subs))
        {
            sub = await _client.GetSubscriber(id, token);
        }
        else
        {
            sub = subs.FirstOrDefault(x => x.Id == id);
        }

        return sub;
    }
}

