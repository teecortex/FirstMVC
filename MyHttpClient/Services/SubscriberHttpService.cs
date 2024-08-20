using System.Net.Http.Json;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace MyHttpClient.Services;

public class SubscriberHttpService : ISubscriberHttpClient
{
    private readonly HttpClient _httpClient;

    public SubscriberHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Subscriber[]?> GetSubscribers(CancellationToken token)
    {
        var uri = new Uri(_httpClient.BaseAddress + "api/subscribers");
        var subs = await _httpClient.GetFromJsonAsync<Subscriber[]?>(uri);

        return subs;
    }

    public async Task<Subscriber?> GetSubscriber(int id, CancellationToken token)
    {
        var uri = new Uri(_httpClient.BaseAddress + $"api/subscribers/{id}");
        var sub = await _httpClient.GetFromJsonAsync<Subscriber?>(uri);

        return sub;
    }
}