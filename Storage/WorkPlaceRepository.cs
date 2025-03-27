using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Repositories
{
    public class WorkPlaceRepository : BaseRepository<WorkPlace>, IWorkPlaceRepository
    {
        public WorkPlaceRepository(ResumeFinderContext context) : base(context)
        {
        }
    }
}
