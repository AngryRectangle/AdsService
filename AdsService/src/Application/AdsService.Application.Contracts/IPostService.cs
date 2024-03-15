namespace AdsService.Application.Contracts;

using AdsService.Application.Models.Dto;
using AdsService.Application.Models.ValueObjects;

public interface IPostService
{
    /// <summary>
    /// Метод для создания нового поста
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="content">Содержание поста</param>
    /// <returns>DTO объект созданного поста</returns>
    public PostDto CreatePost(Jwt jwt, PostContent content);

    /// <summary>
    /// Метод для получения статуса поста (одобрен/отклонен модератором)
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="postId">Идентификатор поста</param>
    /// <returns>Статус поста</returns>
    public PostStatus GetStatus(Jwt jwt, Guid postId);

    /// <summary>
    /// Метод для получения причины отклонения поста модератором
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="postId">Идентификатор поста</param>
    /// <param name="rejectionReason">Причина отклонения (если есть)</param>
    /// <returns>Получена ли причина отклонения</returns>
    public bool TryGetRejectionReason(Jwt jwt, Guid postId, out Reason rejectionReason);

    /// <summary>
    /// Метод для получения всех постов, которые ожидают проверки модератора
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <returns>Список DTO объектов постов, ожидающих проверку</returns>
    public IReadOnlyCollection<PostDto> GetAllPostsForModeration(Jwt jwt);

    /// <summary>
    /// Метод для получения всех постов пользователя
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <returns>Список DTO объектов всех постов</returns>
    public IReadOnlyCollection<PostDto> GetAllPosts(Jwt jwt);
}