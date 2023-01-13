
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Host.ValueObjects;

public sealed class HostId : EntityId<HostId>
{
    private HostId(Guid value) : base(value)
    {
    }
}
