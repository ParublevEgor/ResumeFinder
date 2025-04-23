using ResumeFinder.Domain.Models;

namespace ResumeFinder.Domain.Contracts
{
    /// <summary>
    /// Сервис для работника
    /// </summary>
    public interface IWorkerService : IBaseService<Worker>
    {
        /// <summary>
        /// Загрузка аватарки работника
        /// </summary>
        /// <param name="image">Аватарка</param>
        /// <param name="workerId">Id работника</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>UUID аватарки</returns>
        Task UploadAvatarImageAsync(Stream image, long workerId, CancellationToken token);

        /// <summary>
        /// Получение аватарки по UUID
        /// </summary>
        /// <param name="workerId">Id работника</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Аватарку</returns>
        Task<Stream> GetAvatarAsync(long workerId, CancellationToken token);

        /// <summary>
        /// Удаление аватарки
        /// </summary>
        /// <param name="workerId">Id работника</param>
        /// <param name="token">Токен отмены</param>
        /// <returns></returns>
        Task RemoveAvatarAsync(long workerId, CancellationToken token);
    }
}
