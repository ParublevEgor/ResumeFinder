using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    /// <summary>
    /// Сервис для сущности специализация
    /// </summary>
    public class SpecializationService : BaseService<Specialization>, ISpecializationService
    {
        /// <summary>
        /// Метод для извлечения данных из репозитория
        /// </summary>
        /// <param name="repository">Репозиторий специализации</param>
        public SpecializationService(ISpecializationRepository repository) : base(repository)
        {
        }
    }
}
