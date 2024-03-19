namespace AdsService.Application.Contracts;

using AdsService.Application.Models.ValueObjects;

public interface IModerationService
{
    public class WrongTokenException : UnauthorizedAccessException
    {
        public WrongTokenException() : base("The token is incorrect6 you can't top up your balance.")
        {
        }
    }

    public class WrongPostIdException : ArgumentException
    {
        public WrongPostIdException() : base("There is no post with this id.")
        {
        }
    }

    public class ReasonLengthExceededException : ArgumentException
    {
        public ReasonLengthExceededException() : base("Reason length can't exceed 100 symbols.")
        {
        }
    }

    public class JwtPostIdMismatchException : ArgumentException
    {
        public JwtPostIdMismatchException() : base("This user does not have post with this id.")
        {
        }
    }

    public class EmptyReasonException : ArgumentException
    {
        public EmptyReasonException() : base("Reason cannot be empty.")
        {
        }
    }

    /// <summary>
    /// Одобрение поста модератором
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации модератора</param>
    /// <param name="postId">Идентификатор поста</param>
    /// <remarks>
    /// Данный параметр необходим для запуска рекламной компании
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный</exception>
    /// <exception cref="WrongPostIdException">Поста с таким id не сущетвует</exception>
    /// <exception cref="JwtPostIdMismatchException">У пользователя нет поста с таким id</exception>
    void ApprovePost(Jwt jwt, Guid postId);

    /// <summary>
    /// Отклонение поста модератором с указанием причины
    /// </summary>
    /// <param name="jwt">JWT токен для аутентификации модератора</param>
    /// <param name="postId">Идентификатор поста</param>
    /// <param name="reason">Причина отклонения</param>
    /// <remarks>
    /// Данный параметр препятствует запуску рекламной компании на пост.
    /// Причина при отклонении обязательна
    /// </remarks>
    /// <exception cref="WrongTokenException">Токен для аутентификации неверный</exception>
    /// <exception cref="WrongPostIdException">Поста с таким id не сущетвует</exception>
    /// <exception cref="ReasonLengthExceededException">Причина не может содержать более 100 символов</exception>
    /// <exception cref="JwtPostIdMismatchException">У пользователя нет поста с таким id</exception>
    /// <exception cref="EmptyReasonException">Причина должна быть написана</exception>
    void RejectPost(Jwt jwt, Guid postId, Reason reason);
}