
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill.ValueObjects;

public sealed class BillId : EntityId<BillId>
{
    public BillId(Guid value) : base(value)
    {
    }
}
