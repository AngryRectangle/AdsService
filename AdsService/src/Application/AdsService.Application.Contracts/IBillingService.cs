namespace AdsService.Application.Contracts;

using AdsService.Application.Models.ValueObjects;

public interface IBillingService
{
    public class WrongTokenException : UnauthorizedAccessException
    {
        public WrongTokenException() : base("The token is incorrect6 you can't top up your balance.")
        {
        }
    }

    public class BalanceException : ArgumentOutOfRangeException
    {
        public BalanceException() : base("The replenishment amount must be greater than 0.")
        {
        }
    }

    /// <summary>
    /// Пополнение баланса пользователя
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="amount">Сумма для пополнения баланса</param>
    /// <remarks>
    /// Сервис просто верит пользователю, так как у нас нет реальной платёжной системы.
    /// В дальнейшем баланс проверяется при попытке запуска рекламной компании,
    /// списываются деньги для её оплаты
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный, Вы не можете пополнить баланс</exception>
    /// <exception cref="BalanceException">Сумма пополнения должна быть больше 0</exception>
    void TopUpBalance(Jwt jwt, Money amount);
}