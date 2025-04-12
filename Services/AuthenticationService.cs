using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Models.Enums;
using ResumeFinder.Services.Params;
using System.Security.Cryptography;
using System.Text;

namespace ResumeFinder.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IWorkerService _workerService;
        private readonly ICustomerService _customerService;

        public AuthenticationService(IUserService userService, IWorkerService workerService, ICustomerService customerService)
        {
            _userService = userService;
            _workerService = workerService;
            _customerService = customerService;
        }

        public Task<User?> GetByLoginAndPasswordAsync(string login, string password, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> RegisterCustomerAsync(RegisterCustomerParams registerParams, CancellationToken token)
        {
            User createdUser = await AddUserAsync(registerParams.Login, registerParams.Password, Role.Customer, token);

            Customer customer = new Customer()
            {
                Name = registerParams.Name,
                Surname = registerParams.Surname,
                PhoneNumber = registerParams.PhoneNumber,
                Email = registerParams.Email,
                CompanyName = registerParams.CompanyName,
                UserId = createdUser.Id
            };
            return await _customerService.AddAsync(customer, token);
        }

        public async Task<Worker> RegisterWorkerAsync(RegisterWorkerParams registerParams, CancellationToken token)
        {
            User createdUser = await AddUserAsync(registerParams.Login, registerParams.Password, Role.Worker, token);

            Worker worker = new Worker()
            {
                Name = registerParams.Name,
                Surname = registerParams.Surname,
                Birthday = registerParams.Birthday,
                PhoneNumber = registerParams.PhoneNumber,
                Email = registerParams.Email,
                Gender = registerParams.Gender,
                Information = registerParams.Information,
                UserId = createdUser.Id
            };
            return await _workerService.AddAsync(worker, token);
        }

        private async Task<User> AddUserAsync(string login, string password, Role role, CancellationToken token)
        {
            string hash = ComputeHash(password);
            User user = new User()
            {
                Login = login,
                PasswordHash = hash,
                Role = role
            };
            return await _userService.AddAsync(user, token);
        }

        private string ComputeHash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
