
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public sealed class MenuItemId : EntityId<MenuItemId>
{
    private MenuItemId(Guid value) : base(value)
    {
    }
}
