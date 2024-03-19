namespace AdsService.Application.Contracts;

using AdsService.Application.Models.ValueObjects;

public interface IAccountService
{
    public class WrongPasswordException : InvalidOperationException
    {
        public WrongPasswordException() : base("The password is incorrect.")
        {
        }
    }

    public class EmailNotFoundException : UnauthorizedAccessException
    {
        public EmailNotFoundException() : base("This email is not registered.")
        {
        }
    }

    public class WrongEmailException : InvalidOperationException
    {
        public WrongEmailException() : base("The email is incorrect.")
        {
        }
    }

    public class EmailAlreadyRegisteredException : UnauthorizedAccessException
    {
        public EmailAlreadyRegisteredException() : base("A user with such email has already been registered.")
        {
        }
    }

    /// <summary>
    /// Вход пользователя в систему
    /// </summary>
    /// <param name="email">Почта пользователя</param>
    /// <param name="password">Пароль пользователя</param>
    /// <returns>JWT токен для аутентификации пользователя</returns>
    /// <exception cref="WrongPasswordException">Неправильный пароль</exception>
    /// <exception cref="EmailNotFoundException">Такая почта не зарегистрирована в системе</exception>
    public Jwt LoginUser(UserMail email, PasswordHash password);

    /// <summary>
    /// Вход модератора в систему
    /// </summary>
    /// <param name="email">Почта модератора</param>
    /// <param name="password">Пароль модератора</param>
    /// <returns>JWT токен для аутентификации модератора</returns>
    /// <exception cref="WrongPasswordException">Неправильный пароль</exception>
    /// <exception cref="EmailNotFoundException">Такая почта не зарегистрирована в системе</exception>
    public Jwt LoginModerator(UserMail email, PasswordHash password);

    /// <summary>
    /// Регистрация пользователя в системе
    /// </summary>
    /// <param name="email">Почта пользователя</param>
    /// <param name="password">Пароль пользователя</param>
    /// <returns>JWT токен, который используется для авторизации пользователя,
    /// если данные совпадают с тем что сохранено при входе в систему,
    /// иначе пользователь получает ответ о том что аутентификация не пройдена.
    /// </returns>
    /// <remarks>
    /// Используется для пополнения баланса, начала и остановки рекламной компании, получения аналитики, списка рекламных компаний
    /// создания поста, получения списка всех постов
    /// </remarks>
    /// <exception cref="EmailAlreadyRegisteredException">Пользователь с такой почтой уже зарегистрирован в системе</exception>
    /// <exception cref="WrongEmailException">Почта указана неверно</exception>
    public Jwt RegisterUser(UserMail email, PasswordHash password);

    /// <summary>
    /// Регистрация модератора в системе
    /// </summary>
    /// <param name="email">Почта модератора</param>
    /// <param name="password">Пароль модератора</param>
    /// <returns>JWT токен, который используется для авторизации модератора,
    /// если данные совпадают с тем что сохранено при входе в систему,
    /// иначе модератор получает ответ о том что аутентификация не пройдена.
    /// </returns>
    /// <remarks>
    /// Используется для получения списка всех постов, которые ожидают проверки,
    /// для установления одобрения или отклонения поста
    /// </remarks>
    /// <exception cref="EmailAlreadyRegisteredException">Модератор с такой почтой уже зарегистрирован в системе</exception>
    /// <exception cref="WrongEmailException">Почта указана неверно</exception>
    public Jwt RegisterModerator(UserMail email, PasswordHash password);
}