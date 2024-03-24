namespace AdsService.Application.Models.ValueObjects;

public readonly struct Name
{
    public const int MaxLength = 64;
    
    public string Value { get; }

    public Name(string value)
    {
        Value = value;
        if (value.Length > MaxLength)
            throw new ArgumentException($"Name length can't exceed {MaxLength} symbols.", nameof(value));
    }

    public Name()
    {
        Value = "Empty name";
    }
}