using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces;

public interface ISubscriberService
{
    Task<Subscriber[]?> GetSubscribers(CancellationToken token);
    Task<Subscriber?> GetSubscriber(int id, CancellationToken token);
}