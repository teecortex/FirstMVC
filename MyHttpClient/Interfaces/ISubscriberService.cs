using MyHttpClient.Entities;

namespace MyHttpClient.Interfaces;

public interface ISubscriberService
{
    Task<Subscriber?[]> GetSubscribers();
}