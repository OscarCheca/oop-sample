namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

public readonly record struct Address
{
    public string Street
    {
        get => field ?? string.Empty;

        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length > 100)
                throw new ArgumentException("Address Street must be less than 100 characters.", nameof(value));
            field = value;
        }
    }

    public string Number
    {
        get => field ?? string.Empty;

        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length > 10)
                throw new ArgumentException("Address Street Number must be less than 10 characters.", nameof(value));
            field = value;
        }
    }

    public string City
    {
        get => field ?? string.Empty;

        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length > 100)
                throw new ArgumentException("Address City must be less than 100 characters.", nameof(value));
            field = value;
        }
    }
    
    public string? StateOrRegion { get; init; }

    public string PostalCode
    {
        get => field ?? string.Empty;
        
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length > 20)
                throw new ArgumentException("Address Postal Code must be less than 20 characters.", nameof(value));
            field = value;
        }
    }

    public string Country
    {
        get => field ?? string.Empty;
        
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length > 100)
                throw new ArgumentException("Address Country must be less than 100 characters.", nameof(value));
            field = value;
        }
    }

    public Address() =>
        throw new InvalidOperationException(
            "Address must be initialized with street, number, city, postal code, and country.");

    public Address(string street, string number, string city, string? stateOrRegion, string postalCode, string country)
    {
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        PostalCode = postalCode;
        Country = country;
    }
    
    public override string ToString() => string.IsNullOrWhiteSpace(StateOrRegion)
        ? $"{Street} {Number}, {City}, {PostalCode}, {Country}"
        : $"{Street} {Number}, {City}, {StateOrRegion}, {PostalCode}, {Country}";

}