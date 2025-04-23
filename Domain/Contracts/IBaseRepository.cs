using ResumeFinder.Domain.Models;

namespace ResumeFinder.Domain.Storage
{
    /// <summary>
    /// Интерфейс базового репозитория
    /// </summary>
    /// <typeparam name="T">Тип, реализующий IEntity</typeparam>
    public interface IBaseRepository<T> where T : IEntity
    {
        /// <summary>
        /// Асинхронное добавление сущности
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Добавленная сущность</returns>
        Task<T> AddAsync(T entity, CancellationToken token);

        /// <summary>
        /// Асинхронное обновление сущности
        /// </summary>
        /// <param name="entity">сущность</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Обновлённая сущность</returns>
        Task<T> UpdateAsync(T entity, CancellationToken token);

        /// <summary>
        /// Асинхронное удаление сущности
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Токен отмены</param>
        /// <returns></returns>
        Task RemoveAsync(long id, CancellationToken token);

        /// <summary>
        /// Асинхронное получение сущности
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Сущность с указанным Id, если не найдена null</returns>
        Task<T?> GetAsync(long id, CancellationToken token);

        /// <summary>
        /// Асинхронное получение всех сущностей
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Все сущности</returns>
        Task<ICollection<T>> GetAllAsync(CancellationToken token);

    }
}
