namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a money value object
/// </summary>
public readonly record struct Money
{
    /// <summary>
    /// The underlying amount.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public decimal Amount
    {
        get;
        init
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            field = value;
        }
    }

    /// <summary>
    /// The currency
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the currency is not provided</exception>
    public Currency Currency
    {
        get;
        init
        {
            if (value==default)
                throw new ArgumentException("Currency is required.", nameof(value));
            field = value;
        }
    }
    
    /// <summary>
    /// Prevents parameterless construction of <see cref="Money"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the money is initializd with a parameterless constructor</exception>
    public Money() => throw new InvalidOperationException("Currency must be initialized with a valid amount and currency.");
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Money"/> value object.
    /// </summary>
    /// <param name="amount">The monetary amount</param>
    /// <param name="currency"></param>
    public Money(decimal amount, Currency currency) 
    {
        Amount = amount;
        Currency = currency;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Money"/> value object.
    /// </summary>
    /// <param name="amount">The monetary amount</param>
    /// <param name="currencyCode">The ISO 4217 alphabetic code of the currency.</param>
    public Money(decimal amount, string currencyCode) : this(amount, new Currency(currencyCode)) { }
    
    /// <summary>
    /// Returns a string representation of the money value object.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"{Amount} {Currency}";

    /// <summary>
    /// Adds two <see cref="Money"/> objects together.
    /// </summary>
    /// <param name="other">The other <see cref="Money"/> Object to add.</param>
    /// <returns>A new <see cref="Money"/>objects.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public Money Add(Money other)
    {
        if (Currency == default || other.Currency == default)
            throw new InvalidOperationException("Cannot add Money with initialized currency.");
        
        if (Currency != other.Currency)
            throw new InvalidOperationException($"Cannot add Money with different currencies: `{Currency}` and `{other.Currency}`.");
        
        return new Money(Amount + other.Amount, Currency);
    }
    
    /// <summary>
    /// Multiply a <see cref="Money"/> object by a decimal factor.
    /// </summary>
    /// <param name="factor">The decimal factor to multiply by.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Money Multiply(decimal factor)
    {
        if (Currency == default)
            throw new InvalidOperationException("Cannot multiply Money with uninitialized currency.");
        
        ArgumentOutOfRangeException.ThrowIfNegative(factor);
        
        return new Money(Amount * factor, Currency);
    }
    
    /// <summary>
    /// Multiply a <see cref="Money"/> object by an integer factor.
    /// </summary>
    /// <param name="factor"></param>
    /// <returns></returns>
    public Money Multiply(int factor) => Multiply((decimal)factor);
    
    /// <summary>
    /// Gets the result of adding two <see cref="Money"/> objects together.
    /// </summary>
    /// <param name="left">The first <see cref="Money"/> object to add.</param>
    /// <param name="right">The second <see cref="Money"/> object to add.</param>
    /// <returns></returns>
    public static Money operator +(Money left, Money right) => left.Add(right);
    
    /// <summary>
    /// Gets the result of multiplying a <see cref="Money"/> object by a decimal factor.
    /// </summary>
    /// <param name="money"></param>
    /// <param name="factor"></param>
    /// <returns></returns>
    public static Money operator *(Money money, decimal factor) => money.Multiply(factor);
    
    /// <summary>
    /// Gets the result of multiplying a <see cref="Money"/> object by a decimal factor.
    /// </summary>
    /// <param name="factor">The integer factor to multiply by.</param>
    /// <param name="money">The <see cref="Money"/>object </param>
    /// <returns></returns>
    public static Money operator *(decimal factor, Money money) => money.Multiply(factor);
    
    /// <summary>
    /// Gets the result of multiplying a <see cref="Money"/> object by an integer factor.
    /// </summary>
    /// <param name="money"></param>
    /// <param name="factor"></param>
    /// <returns></returns>
    public static Money operator *(Money money, int factor) => money.Multiply(factor);

    /// <summary>
    /// Gets the result of multiplying a <see cref="Money"/> object by an integer factor.
    /// </summary>
    /// <param name="factor"></param>
    /// <param name="money"></param>
    /// <returns></returns>
    public static Money operator *(int factor, Money money) => money.Multiply(factor);
}