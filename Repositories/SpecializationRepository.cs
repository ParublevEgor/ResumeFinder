using ResumeFinder.Entities;
using ResumeFinder.Repositories.Interfaces;

namespace ResumeFinder.Repositories
{
    public class SpecializationRepository : BaseRepository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(ResumeFinderContext context) : base(context)
        {
        }
    }
}
