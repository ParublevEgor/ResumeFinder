using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Models.Enums;
using ResumeFinder.DTO;
using ResumeFinder.DTO.Requests;
using ResumeFinder.Services.Params;

namespace ResumeFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthController(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [HttpPost(nameof(RegisterWorker))]
        public async Task<IActionResult> RegisterWorker([FromBody]WorkerRegistrationRequest registrationRequest, CancellationToken token)
        {
            RegisterWorkerParams registerWorkerParams = new RegisterWorkerParams()
            {
                Login = registrationRequest.Login,
                Password = registrationRequest.Password,
                Name = registrationRequest.Name,
                Surname = registrationRequest.Surname,
                Birthday = registrationRequest.Birthday.ToUniversalTime(),
                PhoneNumber = registrationRequest.PhoneNumber,
                Email = registrationRequest.Email,
                Gender = Enum.Parse<Gender>(registrationRequest.Gender),
                Information = registrationRequest.Information
            };
            Worker createdWorker = await _authenticationService.RegisterWorkerAsync(registerWorkerParams, token);
            WorkerDTO workerDTO = _mapper.Map<WorkerDTO>(createdWorker);
            return Ok(workerDTO);
        }

        [HttpPost(nameof(RegisterCustomer))]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRegistrationRequest registrationRequest, CancellationToken token)
        {
            RegisterCustomerParams registerCustomerParams = new RegisterCustomerParams()
            {
                Login = registrationRequest.Login,
                Password = registrationRequest.Password,
                Name = registrationRequest.Name,
                Surname = registrationRequest.Surname,
                PhoneNumber = registrationRequest.PhoneNumber,
                Email = registrationRequest.Email,
                CompanyName = registrationRequest.CompanyName,
            };
            Customer createdCustomer = await _authenticationService.RegisterCustomerAsync(registerCustomerParams, token);
            CustomerDTO customerDTO = _mapper.Map<CustomerDTO>(createdCustomer);
            return Ok(customerDTO);
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody]LoginRequest loginRequest, CancellationToken token)
        {
            string? jwtToken = await _authenticationService.GetByLoginAndPasswordAsync(loginRequest.Login, loginRequest.Password, token);
            if (string.IsNullOrWhiteSpace(jwtToken))
                return Unauthorized();
            return Ok(jwtToken);
        }
    }
}
