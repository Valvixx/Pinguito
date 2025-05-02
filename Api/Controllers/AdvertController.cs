using Application.Dto.Requests.Advert;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace PinguitoAdvertService.Controllers;

[ApiController]
[Route("api/adverts")]
public class AdvertController : ControllerBase
{
    private readonly IAdvertService _advertService;

    public AdvertController(IAdvertService advertService)
    {
        _advertService = advertService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdvertRequest advertRequest)
    {
        return (Ok(await _advertService.CreateAdvert(advertRequest)));
    }
}