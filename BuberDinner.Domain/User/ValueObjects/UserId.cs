
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.User.ValueObjects;

public sealed class UserId : EntityId<UserId>
{
    public UserId(Guid value) : base(value)
    {
    }
}
