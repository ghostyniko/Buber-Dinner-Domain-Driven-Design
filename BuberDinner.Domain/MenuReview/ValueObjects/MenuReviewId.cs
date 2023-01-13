

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

public class MenuReviewId : EntityId<MenuReviewId>
{
    private MenuReviewId(Guid value) : base(value)
    {
    }
}
