namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a currency volue object.
/// </summary>
public readonly record struct Currency
{
    /// <summary>
    /// ISO 4217 alphabetic code.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the value is null, empty, whitespace, or not a 3-letter ISO 4217 alphabetic code.</exception>
    public string Code
    {
        
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length != 3 || !value.All(char.IsAsciiLetter))
                throw new ArgumentException("Currency must be 3-letter ISO 4217 alphabetic code.", nameof(value));
            field = value;
        }
    }
    
    /// <summary>
    /// Prevents parameterless construction of <see cref="InvalidOperationException"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the currrency is initialized with a parameter</exception>
    
    public Currency() => throw new InvalidOperationException("Currency must be initialized with a valid 3-letter ISO 4217 code.");
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> value object.
        /// </summary>
        /// <param name="code">The ISO 4217 alphabetic code.</param>
    public Currency(string code) => Code = code;

    /// <summary>
    /// Returns a string representation of the currency value object.
    /// </summary>
    /// <returns>A string representation of the currency code.</returns>
    public override string ToString() => Code;
}
       