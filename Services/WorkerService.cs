using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    public class WorkerService : BaseService<Worker>, IWorkerService
    {
        public WorkerService(IWorkerRepository repository) : base(repository)
        {
        }
    }
}
