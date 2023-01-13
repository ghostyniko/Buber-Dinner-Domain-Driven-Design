using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public sealed class MenuSectionId : EntityId<MenuSectionId>
{
    private MenuSectionId(Guid value) : base(value)
    {
    }
}

