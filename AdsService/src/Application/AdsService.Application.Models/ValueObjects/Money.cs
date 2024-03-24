namespace AdsService.Application.Models.ValueObjects;

public readonly struct Money
{
    public long Kopecks { get; }

    public Money(int rubles, int kopecks) : this((rubles * 100) + kopecks)
    {
    }

    public Money(long kopecks)
    {
        Kopecks = kopecks;
        if (Kopecks < 0)
            throw new ArgumentException("Cost can't be less than 0.");
    }

    public Money()
    {
        Kopecks = 0;
    }
}