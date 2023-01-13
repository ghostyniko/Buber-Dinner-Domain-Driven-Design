using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu:AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnersIds = new();
    private readonly List<MenuReviewId> _menuReviewId = new();
   
    private Menu(MenuId menuId,
        string name,
        string description, 
        HostId hostId, 
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public string Name{get;}
    public string Description{get;}
    
    public HostId HostId{get;}
    public DateTime CreatedDateTime{get;}
    public DateTime UpdatedDateTime{get;}
    public float AverageRating{get;}
    public IReadOnlyList<MenuSection> Sections => _sections.ToList();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnersIds.ToList();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewId.ToList();
    

}
