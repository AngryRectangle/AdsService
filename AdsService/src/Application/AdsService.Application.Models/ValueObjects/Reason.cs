namespace AdsService.Application.Models.ValueObjects;

public readonly struct Reason
{
    public const int MaxLength = 100;
    
    public string Value { get; }

    public Reason(string value)
    {
        Value = value;
        if (value.Length > MaxLength)
            throw new ArgumentException($"Reason length can't exceed {MaxLength} symbols.", nameof(value));
    }

    public Reason()
    {
        Value = "Empty reason";
    }
}