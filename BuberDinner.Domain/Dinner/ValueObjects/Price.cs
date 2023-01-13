using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public sealed class Price : ValueObject
{
    public Price(double amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public double Amount{get;}
    public string Currency{get;}

    public static Price Create(
        double amount,
        string currency = "EUR")
    {
        return new(amount,currency);
    }
    
    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Amount;
        yield return Currency;
    }
}
