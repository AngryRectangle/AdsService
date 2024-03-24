namespace AdsService.Application.Models.Entities;

using AdsService.Application.Models.ValueObjects;

public class Moderator
{
    public Guid Id { get; } = Guid.NewGuid();

    public UserMail Mail { get; }

    public PasswordHash Password { get; }
    
    public Moderator(UserMail mail, PasswordHash password)
    {
        Mail = mail;
        Password = password;
    }

    private Moderator() { }
}