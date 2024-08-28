using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebProjectMVC.Controllers;

[Route("api/subscribers")]
public class SubscriberController : Controller
{
    private ISubscriberService _subscriberService;
    private readonly ILogger<SubscriberController> _logger;

    public SubscriberController(ISubscriberService subscriberService, ILogger<SubscriberController> logger)
    {
        _subscriberService = subscriberService;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<IActionResult> Subscribers(CancellationToken token)
    {
        _logger.LogInformation("Getting all subscribers");
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