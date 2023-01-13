using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    private List<DinnerId> _upcomingDinnerIds = new();
    private List<DinnerId> _pastDinnerIds = new();
    private List<DinnerId> _pendingDinnerIds = new ();
    private List<BillId> _billIds = new ();
    private List<Rating> _ratings = new();

    private Guest(GuestId id,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public string FirstName{get;}
    public string LastName{get;}
    public string ProfileImage{get;}
    public UserId UserId{get;}
    public DateTime CreatedDateTime{get;}
    public DateTime UpdatedDateTime{get;}
    public double AverageRating => _ratings.Aggregate(0.0,(sum,rating)=>sum+rating.Value)/
                                        _ratings.Count != 0 ? _ratings.Count : 1;
    public List<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.ToList();
    public List<DinnerId> PastDinnerIds => _pastDinnerIds.ToList();
    public List<DinnerId> PendingDinnerIds => _pendingDinnerIds.ToList();
    public List<BillId> BillIds => _billIds.ToList();
    public List<Rating> Ratings => _ratings.ToList();

}
