using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private List<Reservation> _reservations = new();
    public Dinner(DinnerId id,
        string name, 
        string description, 
        DateTime startDateTime, 
        DateTime endDateTime, 
        DinnerStatus dinnerStatus, 
        bool isPublic, 
        int maxGuests, 
        Price price, 
        HostId hostId, 
        MenuId menuId, 
        string imageUrl, 
        Location location, 
        DateTime createdDateTime, 
        DateTime updatedDateTime)
        : base(id)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        DinnerStatus = dinnerStatus;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string Name{get;}
    public string Description {get;}
    public DateTime StartDateTime {get;}
    public DateTime EndDateTime{get;}
    public DinnerStatus DinnerStatus{get;}
    public bool IsPublic{get;}
    public int MaxGuests{get;}
    public Price Price{get;}
    public HostId HostId{get;}
    public MenuId MenuId{get;}
    public string ImageUrl{get;}
    public Location Location{get;}
    public DateTime CreatedDateTime{get;}
    public DateTime UpdatedDateTime{get;}
    public List<Reservation> Reservations => _reservations.ToList();

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            DinnerStatus.Upcoming,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

}

public enum DinnerStatus
{
    Upcoming, InProgress, Ended, Cancelled
}

