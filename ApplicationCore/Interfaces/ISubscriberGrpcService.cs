using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces;

public interface ISubscriberGrpcService
{
    Task<Subscriber[]?> GetSubscribers();
    Task<Subscriber?> GetSubscriber(int id);
}