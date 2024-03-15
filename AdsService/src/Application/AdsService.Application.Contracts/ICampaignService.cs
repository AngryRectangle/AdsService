namespace AdsService.Application.Contracts;

using AdsService.Application.Models.Dto;
using AdsService.Application.Models.ValueObjects;

public interface ICampaignService
{
    /// <summary>
    /// Метод для запуска рекламной кампании
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="postId">Идентификатор поста, на который будет запущена рекламная компания</param>
    /// <param name="duration">Продолжительность рекламной кампании</param>
    /// <param name="parameters">Параметры рекламной компании</param>
    /// <returns>DTO объект запущенной рекламной кампании</returns>
    AdCampaignDto StartCampaign(Jwt jwt, Guid postId, TimeSpan duration, CampaignParameters parameters);

    /// <summary>
    /// Метод для остановки рекламной кампании
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="campaignId">Идентификатор рекламной кампании</param>
    /// <returns>Остановлена ли рекламная кампания</returns>
    bool TryStopCampaign(Jwt jwt, Guid campaignId);

    /// <summary>
    /// Метод для получения аналитики рекламной кампании
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="campaignId">Идентификатор рекламной кампании</param>
    /// <param name="analytics">Аналитика рекламной кампании</param>
    /// <returns>Получена ли аналитика кампании</returns>
    bool TryGetAnalytics(Jwt jwt, Guid campaignId, out CampaignAnalytics analytics);

    /// <summary>
    /// Метод для получения списка рекламных кампаний пользователя
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <returns>Список DTO объектов рекламных кампаний пользователя</returns>
    IReadOnlyCollection<AdCampaignDto> GetCampaigns(Jwt jwt);
}