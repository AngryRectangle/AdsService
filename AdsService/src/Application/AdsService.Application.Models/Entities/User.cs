namespace AdsService.Application.Models.Entities;

using AdsService.Application.Models.ValueObjects;

public class User
{
    public Guid Id { get; } = Guid.NewGuid();

    public UserMail Mail { get; }
    
    public PasswordHash Password { get; }

    public Name Name { get; }

    public Money Balance { get; } = new(0, 0);
    
    public User(UserMail mail, Name name, PasswordHash password)
    {
        Mail = mail;
        Name = name;
        Password = password;
    }

    private User() { }
}