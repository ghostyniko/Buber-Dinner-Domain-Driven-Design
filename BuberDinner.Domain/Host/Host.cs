
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private List<MenuId> _menuIds = new();
    private List<DinnerId> _dinnerIds = new();
    
    private Host(HostId id,
        string firstName, 
        string lastName, 
        string profileImage,
        UserId userId, 
        double averageRating, 
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        AverageRating = averageRating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

     public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            0,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
    
    public string FirstName{get;}
    public string LastName{get;}
    public string ProfileImage{get;}
    public UserId UserId{get;}
    public double AverageRating{get;}
    public DateTime CreatedDateTime{get;}
    public DateTime UpdatedDateTime{get;}
}
