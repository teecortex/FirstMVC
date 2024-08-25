using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcClient.Services;

public class SubscriberGrpcService : ISubscriberGrpcService
{
    private readonly SubscriberService.SubscriberServiceClient _client;

    public SubscriberGrpcService(SubscriberService.SubscriberServiceClient client)
    {
        _client = client;
    }

    public async Task<Subscriber[]?> GetSubscribers()
    {
        var subsReply = await _client.ListSubscribersAsync(new Empty(), new CallOptions());

        var subs = subsReply.Subscribers.Select(x => new Subscriber()
        {
            Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Patronymic = x.Patronymic??null,
            DateOfBirth = DateTime.Parse(x.DateOfBirth), PhoneNumber = x.PhoneNumber, Email = x.Email, 
            Rating = x.Rating, TariffId = x.TariffId??null, 
            DateOfUpdate = DateTime.TryParse(x.DateOfUpdate, out DateTime dateOfUpdate) ? dateOfUpdate : null, 
            DateOfCreation = DateTime.TryParse(x.DateOfCreation, out DateTime dateOfCreation) ? dateOfCreation : null
        }).ToArray();

        return subs;
    }

    public async Task<Subscriber?> GetSubscriber(int id)
    {
        var subReply = await _client.GetSubscriberAsync(new GetSubscriberRequest(){Id = id}, new CallOptions());

        if (subReply.Id == 0)
        {
            return null;
        }

        var sub = new Subscriber()
        {
            Id = subReply.Id, FirstName = subReply.FirstName, LastName = subReply.LastName,
            Patronymic = subReply.Patronymic??null,
            DateOfBirth = DateTime.Parse(subReply.DateOfBirth), PhoneNumber = subReply.PhoneNumber,
            Email = subReply.Email,
            Rating = subReply.Rating, TariffId = subReply.TariffId,
            DateOfUpdate = DateTime.TryParse(subReply.DateOfUpdate, out DateTime dateOfUpdate) ? dateOfUpdate : null,
            DateOfCreation = DateTime.TryParse(subReply.DateOfCreation, out DateTime dateOfCreation) ? dateOfCreation : null
        };

        return sub;
    }
}