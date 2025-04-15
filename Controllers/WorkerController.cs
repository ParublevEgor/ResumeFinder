using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.DTO;

namespace ResumeFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            ICollection<Worker> workers = await _workerService.GetAllAsync(token);
            ICollection<WorkerDTO> workerDTOs = _mapper.Map<ICollection<WorkerDTO>>(workers);
            return Ok(workerDTOs);
        }

        [HttpGet(nameof(Get))]
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> Get([FromQuery]long id, CancellationToken token)
        {
            Worker? worker = await _workerService.GetAsync(id, token);
            WorkerDTO? workerDTO = _mapper.Map<WorkerDTO>(worker);
            return Ok(workerDTO);
        }

        [HttpPut(nameof(Update))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Update([FromBody]WorkerDTO workerDTO, CancellationToken token)
        {
            Worker worker = _mapper.Map<Worker>(workerDTO);
            Worker updatedWorker = await _workerService.UpdateAsync(worker, token);
            WorkerDTO updatedWorkerDTO = _mapper.Map<WorkerDTO>(updatedWorker);
            return Ok(updatedWorkerDTO);
        }

        [HttpDelete(nameof(Delete))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Delete([FromQuery] long id, CancellationToken token)
        {
            await _workerService.RemoveAsync(id, token);
            return Ok();
        }

        [HttpDelete(nameof(RemoveAvatar))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> RemoveAvatar([FromQuery] long id, CancellationToken token)
        {
            await _workerService.RemoveAvatarAsync(id, token);
            return Ok();
        }

        [HttpPost(nameof(UploadAvatar))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> UploadAvatar([FromQuery] long workerId, IFormFile file, CancellationToken token)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Файл не указан.");
            using var stream = file.OpenReadStream();
            await _workerService.UploadAvatarImageAsync(stream, workerId, token);
            return Ok();
        }

        [HttpGet(nameof(GetAvatar))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> GetAvatar([FromQuery] long workerId, CancellationToken token)
        {
            try
            {
                var stream = await _workerService.GetAvatarAsync(workerId, token);
                return File(stream, "image/jpg");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
