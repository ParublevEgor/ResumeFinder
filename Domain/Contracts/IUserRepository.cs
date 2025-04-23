using ResumeFinder.Domain.Models;

namespace ResumeFinder.Domain.Storage
{
    /// <summary>
    /// Репозиторий пользователя
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Получение данных о пользователе
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="passwordHash">Пароль</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Данные о пользователе</returns>
        Task<User?> GetByLoginAndPasswordAsync(string login, string passwordHash, CancellationToken token);
    }
}
