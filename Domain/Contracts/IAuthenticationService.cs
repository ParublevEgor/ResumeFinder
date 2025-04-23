using ResumeFinder.Domain.Models;
using ResumeFinder.Services.Params;

namespace ResumeFinder.Domain.Contracts
{
    /// <summary>
    /// Сервис для аутентификации пользователей
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Получение данных пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Данные о пользователе</returns>
        Task<string?> GetByLoginAndPasswordAsync(string login, string password, CancellationToken token);

        /// <summary>
        /// Регистрация работника
        /// </summary>
        /// <param name="registerParams">Вводимые данные при регистрации</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Данные о работнике</returns>
        Task<Worker> RegisterWorkerAsync(RegisterWorkerParams registerParams, CancellationToken token);

        /// <summary>
        /// Регистрация заказчика
        /// </summary>
        /// <param name="registerParams">Вводимые данные при регистрации</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Данные о заказчике</returns>
        Task<Customer> RegisterCustomerAsync(RegisterCustomerParams registerParams, CancellationToken token);
    }
}
