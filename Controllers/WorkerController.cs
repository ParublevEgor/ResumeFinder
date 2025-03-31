using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.DTO;

namespace ResumeFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService, IMapper mapper)
        {
            _workerService = workerService;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            ICollection<Worker> workers = await _workerService.GetAllAsync(token);
            ICollection<WorkerDTO> workerDTOs = _mapper.Map<ICollection<WorkerDTO>>(workers);
            return Ok(workerDTOs);
        }
    }
}
