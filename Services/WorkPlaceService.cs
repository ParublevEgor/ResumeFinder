using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    /// <summary>
    /// Сервис для сущности место работы
    /// </summary>
    public class WorkPlaceService : BaseService<WorkPlace>, IWorkPlaceService
    {
        /// <summary>
        /// Метод для извлечения данных из репозитория
        /// </summary>
        /// <param name="repository">Репозиторий мест работы</param>
        public WorkPlaceService(IWorkPlaceRepository repository) : base(repository)
        {
        }
    }
}
