using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Domain.Contracts
{
    /// <summary>
    /// Репозиторий заказчика
    /// </summary>
    public interface ICustomerRepository :IBaseRepository<Customer>
    {
    }
}
