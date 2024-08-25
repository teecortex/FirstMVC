using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces;

public interface ISubscriberGraphqlService
{
    Task<Subscriber[]?> GetSubscribers(CancellationToken token);
    Task<Subscriber?> GetSubscriber(int id, CancellationToken token);
}