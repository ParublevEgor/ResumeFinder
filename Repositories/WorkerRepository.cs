using ResumeFinder.Entities;
using ResumeFinder.Repositories.Interfaces;

namespace ResumeFinder.Repositories
{
    public class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(ResumeFinderContext context) : base(context)
        {
        }
    }
}
