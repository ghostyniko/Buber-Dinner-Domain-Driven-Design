namespace BuberDinner.Domain.Common.Models;

public class EntityId<T> : ValueObject
    where T: EntityId<T>, new()
{
    public Guid Value { get; private set; }
    private EntityId(Guid value)
    {
        Value = value;
    }
    protected EntityId() : this(Guid.NewGuid())
    { }

    public static T CreateUnique()
    {
        T id = new T();
        return id;
    }

    public static T Create (string id)
    {
        return new T()
        {
            Value = new Guid(id)
        };
    }
    public static T Create (Guid id)
    {
        return new T()
        {
            Value = id
        };
    }
    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}
