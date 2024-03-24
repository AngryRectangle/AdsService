namespace AdsService.Application.Contracts;

using AdsService.Application.Models.Dto;
using AdsService.Application.Models.ValueObjects;

public interface IPostService
{
    public class WrongTokenException : UnauthorizedAccessException
    {
        public WrongTokenException() : base("The token is incorrect you can't top up your balance.")
        {
        }
    }

    public class WrongPostIdException : ArgumentException
    {
        public WrongPostIdException() : base("There is no post with this id.")
        {
        }
    }

    public class JwtPostIdMismatchException : ArgumentException
    {
        public JwtPostIdMismatchException() : base("This user does not have post with this id.")
        {
        }
    }

    public class ContentLengthExceededException : ArgumentException
    {
        public ContentLengthExceededException() : base("Content length cannot exceed 1024 symbols.")
        {
        }
    }

    public class EmptyContentException : ArgumentException
    {
        public EmptyContentException() : base("Post content cannot be empty.")
        {
        }
    }

    public class PostStatusMismatchtException : ArgumentException
    {
        public PostStatusMismatchtException() : base("Moderator approved the post.")
        {
        }
    }

    /// <summary>
    /// Создание нового поста
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="content">Содержание поста</param>
    /// <returns>DTO объект созданного поста</returns>
    /// <remarks>
    /// Клиент создаёт пост в виде json. В пост можно вставить один текстовый элемент и одну картинку, опционально.
    /// Картинка вставляется как ссылка на саму картинку.
    /// Если с данными всё ок и JWT валиден, то создаётся пост со статусом "На проверке" от имени этого пользователя.
    /// В дальнейшем пост должен быть проверен модератором, и если проверка пройдена, его можно использовать
    /// для запуска рекламной компании
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный</exception>
    /// <exception cref="ContentLengthExceededException">Пост не может содержать более 1024 символов</exception>
    /// <exception cref="EmptyContentException">Содержание поста не может быть пустым</exception>
    public PostDto CreatePost(Jwt jwt, PostContent content);

    /// <summary>
    /// Получение статуса поста (одобрен/отклонен модератором)
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="postId">Идентификатор поста</param>
    /// <returns>Статус поста (Moderation, Approved или Rejected)</returns>
    /// <remarks>
    /// Используется для запуска реклманой компании
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный</exception>
    /// <exception cref="WrongPostIdException">Поста с таким id не сущетвует</exception>
    /// <exception cref="JwtPostIdMismatchException">У пользователя нет поста с таким id</exception>
    public PostStatus GetStatus(Jwt jwt, Guid postId);

    /// <summary>
    /// Получение причины отклонения поста модератором
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <param name="postId">Идентификатор поста</param>
    /// <param name="rejectionReason">Причина отклонения (если есть)</param>
    /// <returns>Получена ли причина отклонения</returns>
    /// <remarks>
    /// Длина причины не может превышать 100 символов. Её наличие обязательно, если пост отклонен
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный</exception>
    /// <exception cref="WrongPostIdException">Поста с таким id не сущетвует</exception>
    /// <exception cref="JwtPostIdMismatchException">У пользователя нет поста с таким id</exception>
    /// <exception cref="PostStatusMismatchtException">Пост одобрен модератором</exception>
    public bool TryGetRejectionReason(Jwt jwt, Guid postId, out Reason rejectionReason);

    /// <summary>
    /// Получение всех постов, которые ожидают проверки модератора
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <returns>Список DTO объектов постов, ожидающих проверку</returns>
    /// <remarks>
    /// Модератор использует список постов для проверки
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный</exception>
    public IReadOnlyCollection<PostDto> GetAllPostsForModeration(Jwt jwt);

    /// <summary>
    /// Получение всех постов пользователя
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации пользователя</param>
    /// <returns>Список DTO объектов всех постов</returns>
    /// <remarks>
    /// Пользватель может посмотреть все свои посты
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный</exception>
    public IReadOnlyCollection<PostDto> GetAllPosts(Jwt jwt);
}