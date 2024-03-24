namespace AdsService.Application.Models.ValueObjects;

public readonly struct PasswordHash
{
    public const int HashSize = 64;
    public const int HashHexSize = HashSize * 2;
    
    public string Password { get; }

    public PasswordHash(string password)
    {
        // TODO: Add real hash calculation with salt and pepper mmmmm yammy.
        Password = password;
        if (password.Length > 50)
            throw new ArgumentException("Password length can't exceed 50 symbols.", nameof(password));
    }

    public PasswordHash()
    {
        Password = "Empty password";
    }
}