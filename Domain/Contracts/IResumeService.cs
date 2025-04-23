using ResumeFinder.Domain.Models;

namespace ResumeFinder.Domain.Contracts
{
    /// <summary>
    /// Сервис для работы с резюме
    /// </summary>
    public interface IResumeService : IBaseService<Resume>
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
