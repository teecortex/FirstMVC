using Microsoft.AspNetCore.Mvc;
using MyHttpClient.Interfaces;

namespace WebProjectMVC.Controllers;

public class SubscriberController : Controller
{
    private ISubscriberService _subscriberService;

    public SubscriberController(ISubscriberService subscriberService)
    {
        _subscriberService = subscriberService;
    }

    [HttpGet, Route("api/subscribers")]
    public async Task<IActionResult> Subscribers()
    {
        var response = await _subscriberService.GetSubscribers();
        ViewBag.Result = response;
        return View();
    }
}