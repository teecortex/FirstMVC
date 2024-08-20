using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces;

public interface ISubscriberHttpClient
{
    Task<Subscriber[]?> GetSubscribers(CancellationToken token);
    Task<Subscriber?> GetSubscriber(int id, CancellationToken token);
}