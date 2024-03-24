namespace AdsService.Application.Contracts;

using AdsService.Application.Models.Dto;
using AdsService.Application.Models.ValueObjects;

public interface ICampaignService
{
    public class WrongTokenException : UnauthorizedAccessException
    {
        public WrongTokenException() : base("The token is incorrect6 you can't top up your balance.")
        {
        }
    }

    public class NotEnoughMoneyException : InvalidOperationException
    {
        public NotEnoughMoneyException() : base("You do not have enough money in your account, please top up your balance.")
        {
        }
    }

    public class WrongPostIdException : ArgumentException
    {
        public WrongPostIdException() : base("There is no post with this id.")
        {
        }
    }

    public class DurationException : ArgumentOutOfRangeException
    {
        public DurationException() : base("The duration cannot be 0.")
        {
        }
    }

    public class WrongCampaignIdException : ArgumentException
    {
        public WrongCampaignIdException() : base("There is no campaign with this id.")
        {
        }
    }

    public class NotLaunchedCampaignException : ArgumentException
    {
        public NotLaunchedCampaignException() : base("The campaign(s) is(are) not launched.")
        {
        }
    }

    /// <summary>
    /// Запуск рекламной кампании
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="postId">Идентификатор поста, на который будет запущена рекламная компания</param>
    /// <param name="duration">Продолжительность рекламной кампании</param>
    /// <param name="parameters">Параметры рекламной компании</param>
    /// <returns>DTO объект запущенной рекламной кампании, в случае если
    /// у пользователя достаточно денег на счету и пост успешно прошел модерацию,
    /// иначе запуск компании невозможен
    /// </returns>
    /// <remarks>
    /// После запуска кампании часть денег на счету пользователя блокируется для оплаты кампании
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный, Вы не можете запустить рекламную кампанию</exception>
    /// <exception cref="NotEnoughMoneyException">У Вас не хватает денег на счете, пожалуйста, пополните баланс</exception>
    /// <exception cref="WrongPostIdException">Поста с таким id не сущетвует</exception>
    /// <exception cref="DurationException">Продолжительность не может быть 0</exception>
    AdCampaignDto StartCampaign(Jwt jwt, Guid postId, TimeSpan duration, CampaignParameters parameters);

    /// <summary>
    /// Остановка рекламной кампании
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="campaignId">Идентификатор рекламной кампании</param>
    /// <returns>Остановлена ли рекламная кампания</returns>
    /// <remarks>
    /// Кампания автоматически останавливается после того как заканчивается её время.
    /// Рекламная компания может быть остановлена до её самостоятельного завершения,
    /// в случае, если она активна.
    /// Неизрасходованные деньги будут разблокированы, а те что уже были потрачены будут списаны.
    /// Перезапуск невозможен
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный, Вы не можете остановить рекламную компанию</exception>
    /// <exception cref="WrongCampaignIdException">Кампании с таким id не сущетвует</exception>
    /// <exception cref="NotLaunchedCampaignException">Кампания не запущена</exception>
    bool TryStopCampaign(Jwt jwt, Guid campaignId);

    /// <summary>
    /// Получение аналитики рекламной кампании
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="campaignId">Идентификатор рекламной кампании</param>
    /// <param name="analytics">Аналитика рекламной кампании</param>
    /// <returns>Получена ли аналитика кампании</returns>
    /// <remarks>
    /// Если аналитика получена успешна, то она отображает количество кликов
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный, Вы не можете посмотреть аналитику</exception>
    /// <exception cref="WrongCampaignIdException">Кампании с таким id не сущетвует</exception>
    /// <exception cref="NotLaunchedCampaignException">Кампания не запущена, просмотр аналитики невозможен</exception>
    bool TryGetAnalytics(Jwt jwt, Guid campaignId, out CampaignAnalytics analytics);

    /// <summary>
    /// Получение списка рекламных кампаний пользователя
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <returns>Список DTO объектов рекламных кампаний пользователя</returns>
    /// <remarks>
    /// Этот список можно задействовать для просмотра аналитики по каждой компании
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный, Вы не можете посмотреть запущенные рекламные компании</exception>
    /// <exception cref="NotLaunchedCampaignException">Вы не запустили ни одной рекламной кампании</exception>
    IReadOnlyCollection<AdCampaignDto> GetCampaigns(Jwt jwt);
}