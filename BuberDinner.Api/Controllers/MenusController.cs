using BuberDinner.Application.Menus.CreateMenu.Commands;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Menu;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public MenusController(IMediator mediator, IMapper mapper)
    {
       _mediator = mediator;
       _mapper = mapper;
    }
    [HttpPost]
    public async Task<IActionResult> CreateMenuAsync(
        CreateMenuRequest request,
        string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request,hostId));
        var createMenuResult = await _mediator.Send(command);
        return ProblemOrResult(createMenuResult,sr=>_mapper.Map<MenuResponse>(sr));
        
    }
}
