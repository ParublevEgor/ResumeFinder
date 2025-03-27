using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Repositories
{
    public class ResumeRepository : BaseRepository<Resume>, IResumeRepository
    {
        public ResumeRepository(ResumeFinderContext context) : base(context)
        {
        }
    }
}
