namespace Acme.OOProgramming.SupplyChain.Domain.Model.ValueObjects;

public readonly record struct SupplierId
{
    public string Identifier
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value;
        }
    }
    
    public SupplierId() => throw new InvalidOperationException("SupplierId must be initialized with a non-empty string.");
    
    public SupplierId(string identifier) => Identifier = identifier;
    
    public override string ToString() => Identifier;
}