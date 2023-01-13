using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public sealed class MenuId : EntityId<MenuId>
{
    private MenuId(Guid value) : base(value)
    {
    }
}
