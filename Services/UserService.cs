using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    /// <summary>
    /// Сервис для сущности пользователя
    /// </summary>
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Метод для регистрации пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="passwordHash">Пароль</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Сохранение логина и пароля</returns>
        public Task<User?> GetByLoginAndPasswordAsync(string login, string passwordHash, CancellationToken token)
        {
            return _repository.GetByLoginAndPasswordAsync(login, passwordHash, token);
        }
    }
}
