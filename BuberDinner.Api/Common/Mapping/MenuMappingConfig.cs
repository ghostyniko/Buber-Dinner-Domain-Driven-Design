
using BuberDinner.Application.Menus.CreateMenu.Commands;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using Mapster;
using MenuSection = BuberDinner.Domain.Menu.Entities.MenuSection;

namespace BuberDinner.Api.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId),CreateMenuCommand>()
                .Map(dest => dest.HostId,src=>src.HostId)
                .Map(dest=>dest,src=>src.Request);
                
            config.NewConfig<Menu,MenuResponse>()
                .Map(dest => dest.Id,src=>src.Id.Value)
                .Map(dest => dest.AverageRating,src => src.AverageRating)
                .Map(dest => dest.HostId,src => src.HostId.Value)
                .Map(dest => dest.DinnerIds,src => src.DinnerIds.Select(id=>id.Value))
                .Map(dest => dest.MenuReviewIds,src => src.MenuReviewIds.Select(id=>id.Value));


            config.NewConfig<MenuSection,MenuSectionResponse>()
                .Map(dest => dest.Id,src=>src.Id.Value);

            config.NewConfig<MenuItem,MenuItemResponse>()
                .Map(dest => dest.Id,src=>src.Id.Value);
            
        }
    }
}