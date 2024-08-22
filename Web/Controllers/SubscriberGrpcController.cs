using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebProjectMVC.Controllers;


[Route("api/grpc/subscribers")]
public class SubscriberGrpcController : Controller
{
    private readonly ISubscriberGrpcService _service;

    public SubscriberGrpcController(ISubscriberGrpcService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Subscribers()
    {
        var response = await _service.GetSubscribers();
        
        return Ok(response);
    }

    [HttpGet, Route("{id}")]
    public async Task<IActionResult> Subscriber(int id)
    {
        var response = await _service.GetSubscriber(id);

        if (response != null)
        {
            return Ok(response);
        }

        return NotFound();
    }

}