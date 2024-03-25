namespace AdsService.Application.Contracts;

using AdsService.Application.Models.ValueObjects;

public interface IAccountService
{
    public Jwt Login(UserMail email, PasswordHash password);

    public void Register(UserMail email, PasswordHash password);
}