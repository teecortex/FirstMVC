using MyHttpClient.Entities;

namespace MyHttpClient.Interfaces;

public interface ISubscriberService
{
    Task<Subscriber?[]> GetSubscribers(CancellationToken token);
    Task<Subscriber?> GetSubscriber(int id, CancellationToken token);
}