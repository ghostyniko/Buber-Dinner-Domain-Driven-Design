using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public MenuReview(MenuReviewId id,
        HostId hostId, 
        MenuId menuId, 
        GuestId guestId, 
        DinnerId dinnerId)
        : base(id)
    {
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
    }

    public HostId HostId{get;}
    public MenuId MenuId{get;}
    public GuestId GuestId{get;}
    public DinnerId DinnerId{get;}
    public DateTime CreatedDateTime{get;}
    public DateTime UpdatedDateTime{get;}

}
