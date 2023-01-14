using BuberDinner.Application.Menus.CreateMenu.Commands;
using BuberDinner.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    // private readonly IMediator _mediator;
    // private readonly IMapper _mapper;
    // public MenusController(IMediator mediator, IMapper mapper)
    // {
    //    _mediator = mediator;
    //    _mapper = mapper;
    // }
    [HttpPost]
    public IActionResult CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        // var command = _mapper.Map<CreateMenuCommand>(request);
        // var result = await _mediator.Send(request);
        return Ok(request);
    }
}
