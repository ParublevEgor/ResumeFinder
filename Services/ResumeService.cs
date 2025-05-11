using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    /// <summary>
    /// Сервис для сущности резюме
    /// </summary>
    public class ResumeService : BaseService<Resume>, IResumeService
    {
        private readonly IResumeRepository _resumeRepository;

        public ResumeService(IResumeRepository repository) : base(repository)
        {
            _resumeRepository = repository;
        }

        /// <summary>
        /// Метод для извлечения резюме по Id работника
        /// </summary>
        /// <param name="userId">Id работника</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Резюме из репозитория</returns>
        public async Task<ICollection<Resume>> GetByUserAsync(long userId, CancellationToken token)
        {
            return await _resumeRepository.GetByUserAsync(userId, token);
        }
    }
}
