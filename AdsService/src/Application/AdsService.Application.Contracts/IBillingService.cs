namespace AdsService.Application.Contracts;

using AdsService.Application.Models.ValueObjects;

public interface IBillingService
{
    /// <summary>
    /// Метод для пополнения баланса пользователя
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="amount">Сумма для пополнения баланса</param>
    void TopUpBalance(Jwt jwt, Money amount);
}