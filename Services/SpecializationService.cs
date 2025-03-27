using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    public class SpecializationService : BaseService<Specialization>, ISpecializationService
    {
        public SpecializationService(ISpecializationRepository repository) : base(repository)
        {
        }
    }
}
