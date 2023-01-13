using BuberDinner.Domain.Common.Models;
namespace BuberDinner.Domain.Dinner.ValueObjects;

public sealed class ReservationId : EntityId<ReservationId>
{
    private ReservationId(Guid value) : base(value)
    {
    }
}
