
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.CreateMenu.Commands;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var menu = Menu.Create(
            HostId.Create(request.HostId),
            request.Name,
            request.Description,
            request.Sections.ConvertAll(section=>MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(menuItem=>MenuItem.Create(
                    menuItem.Name,
                    menuItem.Description
                ))
            ))
        );
        await _menuRepository.Add(menu);
        return menu;
    }
}
