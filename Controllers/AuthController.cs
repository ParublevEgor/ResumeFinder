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
    /// <summary>
    /// Контроллер для авторизации пользователя
    /// </summary>
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

        /// <summary>
        /// Метод для регистрации работника
        /// </summary>
        /// <param name="registrationRequest">Данные для регистрации</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpPost(nameof(RegisterWorker))]
        public async Task<IActionResult> RegisterWorker([FromBody]WorkerRegistrationRequest registrationRequest, CancellationToken token)
        {
            RegisterWorkerParams registerWorkerParams = _mapper.Map<RegisterWorkerParams>(registrationRequest);

            Worker createdWorker = await _authenticationService.RegisterWorkerAsync(registerWorkerParams, token);
            WorkerDTO workerDTO = _mapper.Map<WorkerDTO>(createdWorker);
            return Ok(workerDTO);
        }

        /// <summary>
        /// Метод для регистрации заказчика
        /// </summary>
        /// <param name="registrationRequest">Данные для регистрации</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpPost(nameof(RegisterCustomer))]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRegistrationRequest registrationRequest, CancellationToken token)
        {
            RegisterCustomerParams registerCustomerParams = _mapper.Map<RegisterCustomerParams>(registrationRequest);

            Customer createdCustomer = await _authenticationService.RegisterCustomerAsync(registerCustomerParams, token);
            CustomerDTO customerDTO = _mapper.Map<CustomerDTO>(createdCustomer);
            return Ok(customerDTO);
        }

        /// <summary>
        /// Метод для входа пользователя
        /// </summary>
        /// <param name="loginRequest">Данные для входа</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
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
