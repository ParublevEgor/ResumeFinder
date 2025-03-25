using ResumeFinder.Entities;
using ResumeFinder.Repositories.Interfaces;

namespace ResumeFinder.Repositories
{
    public class WorkPlaceRepository : BaseRepository<WorkPlace>, IWorkPlaceRepository
    {
        public WorkPlaceRepository(ResumeFinderContext context) : base(context)
        {
        }
    }
}
