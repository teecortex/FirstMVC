using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces;

public interface ISubscriberGrpcClient
{
    Task<Subscriber[]?> GetSubscribers();
    Task<Subscriber?> GetSubscriber(int id);
}