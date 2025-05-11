using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    /// <summary>
    /// Базовый сервис для любой сущности
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    public class BaseService<T> : IBaseService<T> where T : IEntity
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Метод для добавления
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Добавление данных в репозиторий</returns>
        public virtual Task<T> AddAsync(T entity, CancellationToken token)
        {
            return _repository.AddAsync(entity, token);
        }

        /// <summary>
        /// Метод для получения всех данных
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Все данные из репозитория</returns>
        public virtual Task<ICollection<T>> GetAllAsync(CancellationToken token)
        {
            return _repository.GetAllAsync(token);
        }

        /// <summary>
        /// Метод для получения данных
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Данные из репозитория</returns>
        public virtual Task<T?> GetAsync(long id, CancellationToken token)
        {
            return _repository.GetAsync(id, token);
        }

        /// <summary>
        /// Метод для удаления
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Удаление данных из репозитория</returns>
        public virtual Task RemoveAsync(long id, CancellationToken token)
        {
            return _repository.RemoveAsync(id, token);
        }

        /// <summary>
        /// Метод для обновления данных
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Обновление данных в репозитории</returns>
        public virtual Task<T> UpdateAsync(T entity, CancellationToken token)
        {
            return _repository.UpdateAsync(entity, token);
        }
    }
}
