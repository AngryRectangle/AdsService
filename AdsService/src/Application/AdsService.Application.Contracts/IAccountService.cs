namespace AdsService.Application.Contracts;

using AdsService.Application.Models.ValueObjects;

public interface IAccountService
{
    /// <summary>
    /// Метод для входа пользователя в систему
    /// </summary>
    /// <param name="email">Почта пользователя</param>
    /// <param name="password">Пароль пользователя</param>
    /// <returns>JWT токен для аутентификации пользователя</returns>
    public Jwt LoginUser(UserMail email, PasswordHash password);

    /// <summary>
    /// Метод для входа модератора в систему
    /// </summary>
    /// <param name="email">Почта модератора</param>
    /// <param name="password">Пароль модератора</param>
    /// <returns>JWT токен для аутентификации модератора</returns>
    public Jwt LoginModerator(UserMail email, PasswordHash password);

    /// <summary>
    /// Метод для регистрации пользователя в системе
    /// </summary>
    /// <param name="email">Почта пользователя</param>
    /// <param name="password">Пароль пользователя</param>
    /// <returns>JWT токен для аутентификации нового пользователя</returns>
    public Jwt RegisterUser(UserMail email, PasswordHash password);

    /// <summary>
    /// Метод для регистрации модератора в системе
    /// </summary>
    /// <param name="email">Почта модератора</param>
    /// <param name="password">Пароль модератора</param>
    /// <returns>JWT токен для аутентификации нового модератора</returns>
    public Jwt RegisterModerator(UserMail email, PasswordHash password);
}