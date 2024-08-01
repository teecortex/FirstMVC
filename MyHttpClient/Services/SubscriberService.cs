using System.Net.Http.Json;
using MyHttpClient.Entities;
using MyHttpClient.Interfaces;

namespace MyHttpClient.Services;

public class SubscriberService : ISubscriberService
{
    private readonly HttpClient _httpClient;

    public SubscriberService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Subscriber?[]> GetSubscribers()
    {
        
        var uri = new Uri(_httpClient.BaseAddress + "api/subscribers");
        var response = await _httpClient.GetFromJsonAsync<Subscriber?[]>(uri);
        return response;
    }
}