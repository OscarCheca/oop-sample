using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

namespace Acme.OOProgramming.SupplyChain.Domain.Model.ValueObjects.Aggregates;

public class Supplier
{
    public SupplierId Id { get; }

    public string Name
    {
        get;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value;
        }
    }
    
    public Address Address
    {
        get;
        init
        {
           if(value == default)
               throw new ArgumentException("Address cannot be an empty address.", nameof(value));
           field = value;
        }
    }
    
    public Supplier(SupplierId supplierId, string name, Address address)
    {
        Id = supplierId;
        Name = name;
        Address = address;
    }
    
    public Supplier(string identifier, string name, Address address) : this(new SupplierId(identifier), name, address) { }
}