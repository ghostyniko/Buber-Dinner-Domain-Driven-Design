

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class DinnerId : EntityId<DinnerId>
{
    private DinnerId(Guid value) : base(value)
    {
    }
}
