using BuberDinner.Domain.Common.Models;
using Mapster;

namespace BuberDinner.Application.Common.Mapping
{
    public static class MappingExensions
    {
        public static void MapGenericEntityId<T>(this TypeAdapterConfig config) 
            where T:EntityId<T>,new()
        {
            config.NewConfig<EntityId<T>,Guid>()
                .MapWith(entityId => entityId.Value);
            
        }
    }
}