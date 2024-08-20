using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebProjectMVC.Controllers;

[Route("api/subscribers")]
public class SubscriberController : Controller
{
    private ISubscriberService _subscriberService;

    public SubscriberController(ISubscriberService subscriberService)
    {
        _subscriberService = subscriberService;
    }

    [HttpGet]
    public async Task<IActionResult> Subscribers(CancellationToken token)
    {
        var response = await _subscriberService.GetSubscribers(token);
        return View(response);
    }

    [HttpGet, Route("{id}")]
    public async Task<IActionResult> Subscriber(int id, CancellationToken token)
    {
        var response = await _subscriberService.GetSubscriber(id, token);
        if (response == null)
        {
            return NotFound();
        }

        return View(response);
    }
}