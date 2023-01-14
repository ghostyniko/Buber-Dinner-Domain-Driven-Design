using System.Reflection;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;
using Mapster;

namespace BuberDinner.Application.Common.Mapping
{
    public class EntityIdMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // var ids = Assembly
            //     .GetExecutingAssembly()
            //     .GetTypes()
            //     .Where(t=>t.IsSubclassOf(typeof(EntityId<>)) && !t.IsAbstract);
            // foreach(Type t in ids)
            // {
            //     config.ForType(t,typeof(Guid))
            //         .MapWith("","Value");
                
            // }
            config.MapGenericEntityId<BillId>();
            config.MapGenericEntityId<DinnerId>();
            config.MapGenericEntityId<ReservationId>();
            config.MapGenericEntityId<GuestId>();
            config.MapGenericEntityId<HostId>();
            config.MapGenericEntityId<MenuItemId>();
            config.MapGenericEntityId<MenuId>();
            config.MapGenericEntityId<MenuSectionId>();
            config.MapGenericEntityId<MenuReviewId>();
            config.MapGenericEntityId<UserId>();
            
        }

        
    }
}