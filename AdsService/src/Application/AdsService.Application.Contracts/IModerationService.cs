namespace AdsService.Application.Contracts;

using AdsService.Application.Models.ValueObjects;

public interface IModerationService
{
    /// <summary>
    /// Метод для одобрения поста модератором
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации модератора</param>
    /// <param name="postId">Идентификатор поста</param>
    void ApprovePost(Jwt jwt, Guid postId);

    /// <summary>
    /// Метод для отклонения поста модератором с указанием причины
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации модератора</param>
    /// <param name="postId">Идентификатор поста</param>
    /// <param name="reason">Причина отклонения</param>
    void RejectPost(Jwt jwt, Guid postId, Reason reason);
}