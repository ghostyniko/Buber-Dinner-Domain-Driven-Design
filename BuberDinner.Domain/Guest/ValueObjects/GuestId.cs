

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;
public sealed class GuestId : EntityId<GuestId>
{
    public GuestId(Guid value) : base(value)
    {
    }
}
