using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebProjectMVC.Controllers;

[Route("api/graphql/subscribers")]
public class SubscriberGraphqlController : Controller
{
    private readonly ISubscriberGraphqlService _service;

    public SubscriberGraphqlController(ISubscriberGraphqlService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Subscribers(CancellationToken token)
    {
        var subs = await _service.GetSubscribers(token);

        return Ok(subs);
    }

    [HttpGet, Route("{id}")]
    public async Task<IActionResult> Subscriber(int id, CancellationToken token)
    {
        var sub = await _service.GetSubscriber(id, token);

        return sub != null ? Ok(sub) : NotFound();
    }
}