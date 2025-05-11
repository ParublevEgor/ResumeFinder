using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Storage;

namespace ResumeFinder.Services
{
    /// <summary>
    /// Сервис для сущности заказчик
    /// </summary>
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        /// <summary>
        /// Метод для извлечения данных из репозитория
        /// </summary>
        /// <param name="repository">Репозиторий заказчика</param>
        public CustomerService(ICustomerRepository repository) : base(repository)
        {
        }
    }
}
