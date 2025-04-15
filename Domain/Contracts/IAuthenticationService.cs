using ResumeFinder.Domain.Models;
using ResumeFinder.Services.Params;

namespace ResumeFinder.Domain.Contracts
{
    public interface IAuthenticationService
    {
        Task<string?> GetByLoginAndPasswordAsync(string login, string password, CancellationToken token);

        Task<Worker> RegisterWorkerAsync(RegisterWorkerParams registerParams, CancellationToken token);

        Task<Customer> RegisterCustomerAsync(RegisterCustomerParams registerParams, CancellationToken token);
    }
}
