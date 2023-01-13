namespace BuberDinner.Domain.Common.Models;

public class EntityId<T> : ValueObject
    where T: EntityId<T>
{
    public Guid Value { get; }
    protected EntityId(Guid value)
    {
        Value = value;
    }
    public static T CreateUnique() =>(T)new EntityId<T>(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}
