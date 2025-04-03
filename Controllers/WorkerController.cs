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

        [HttpGet(nameof(Get))]
        public async Task<IActionResult> Get([FromQuery]long id, CancellationToken token)
        {
            Worker? worker = await _workerService.GetAsync(id, token);
            WorkerDTO? workerDTO = _mapper.Map<WorkerDTO>(worker);
            return Ok(workerDTO);
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody]WorkerDTO workerDTO, CancellationToken token)
        {
            Worker worker = _mapper.Map<Worker>(workerDTO);
            Worker updatedWorker = await _workerService.UpdateAsync(worker, token);
            WorkerDTO updatedWorkerDTO = _mapper.Map<WorkerDTO>(updatedWorker);
            return Ok(updatedWorkerDTO);
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete([FromQuery] long id, CancellationToken token)
        {
            await _workerService.RemoveAsync(id, token);
            return Ok();
        }
    }
}
