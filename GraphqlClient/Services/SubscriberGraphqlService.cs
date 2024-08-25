using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using StrawberryShake;

namespace GraphqlClient.Services;

public class SubscriberGraphqlService : ISubscriberGraphqlService
{
    private readonly IGraphqlClient _client;

    public SubscriberGraphqlService(IGraphqlClient client)
    {
        _client = client;
    }

    public async Task<Subscriber[]?> GetSubscribers(CancellationToken token)
    {
        var result = await _client.GetSubscribers.ExecuteAsync(token);

        var subs = result.Data?.Subscribers.Select(x => new Subscriber()
        {
            Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Patronymic = x.Patronymic??null, Email = x.Email,
            PhoneNumber = x.PhoneNumber, Rating = x.Rating, DateOfBirth = x.DateOfBirth.Date, TariffId = x.TariffId??null,
            DateOfUpdate = x.DateOfUpdate.HasValue ? x.DateOfUpdate.Value.Date : null, 
            DateOfCreation = x.DateOfCreation.HasValue ? x.DateOfCreation.Value.Date : null
        }).ToArray();

        return subs;
    }

    public async Task<Subscriber?> GetSubscriber(int id, CancellationToken token)
    {
        var result = await _client.GetSubscriber.ExecuteAsync(id, token);

        var subData = result.Data?.Subscriber;

        if (subData == null)
        {
            return null;
        }

        var sub = new Subscriber()
        {
            Id = subData.Id, FirstName = subData.FirstName, LastName = subData.LastName, Patronymic = subData.Patronymic??null, 
            Email = subData.Email, PhoneNumber = subData.PhoneNumber, Rating = subData.Rating, DateOfBirth = subData.DateOfBirth.Date, 
            TariffId = subData.TariffId??null,
            DateOfUpdate = subData.DateOfUpdate.HasValue ? subData.DateOfUpdate.Value.Date : null, 
            DateOfCreation = subData.DateOfCreation.HasValue ? subData.DateOfCreation.Value.Date : null
        };

        return sub;
    }
}