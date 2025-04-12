using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;
using ResumeFinder.Repositories;

namespace ResumeFinder.Storage
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ResumeFinderContext context) : base(context)
        {
        }
    }
}
