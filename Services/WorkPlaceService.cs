using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    public class WorkPlaceService : BaseService<WorkPlace>, IWorkPlaceService
    {
        public WorkPlaceService(IWorkPlaceRepository repository) : base(repository)
        {
        }
    }
}
