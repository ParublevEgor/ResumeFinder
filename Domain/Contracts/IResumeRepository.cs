using ResumeFinder.Domain.Models;

namespace ResumeFinder.Domain.Storage
{
    /// <summary>
    /// Репозиторий резюме
    /// </summary>
    public interface IResumeRepository : IBaseRepository<Resume>
    {
        /// <summary>
        /// Получение резюме по Id пользователя
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Данные из резюме</returns>
        Task<ICollection<Resume>> GetByUserAsync(long userId, CancellationToken token);
    }
}
