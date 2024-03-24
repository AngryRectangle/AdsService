namespace AdsService.Application.Models.ValueObjects;

public readonly struct UserMail
{
    public const int MaxLength = 64;
    
    public string Mail { get; }

    public UserMail(string mail)
    {
        Mail = mail;
        if (mail.Length > MaxLength)
            throw new ArgumentException($"Mail length can't exceed {MaxLength} symbols.", nameof(mail));
    }

    public UserMail()
    {
        Mail = "Empty mail";
    }
}