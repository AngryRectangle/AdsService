namespace AdsService.Application.Models.ValueObjects;

public readonly struct PostContent
{
    public const int MaxLength = 1024;
    
    public string Text { get; }

    public PostContent(string text)
    {
        Text = text;
        if (text.Length > MaxLength)
            throw new ArgumentException($"Content length can't exceed {MaxLength} symbols.", nameof(text));
    }

    public PostContent()
    {
        Text = "Empty content";
    }
}