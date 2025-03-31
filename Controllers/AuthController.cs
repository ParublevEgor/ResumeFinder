using AutoMapper;
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
    }
}
