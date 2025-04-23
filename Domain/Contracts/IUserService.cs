using ResumeFinder.Domain.Models;

namespace ResumeFinder.Domain.Contracts
{
    /// <summary>
    /// Сервис для пользователя
    /// </summary>
    public interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// Получение данных о пользователе
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="passwordHash">Пароль</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Данные пользователя</returns>
        Task<User?> GetByLoginAndPasswordAsync(string login, string passwordHash, CancellationToken token);
    }
}
