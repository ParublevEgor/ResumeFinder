using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.DTO;

namespace ResumeFinder.Controllers
{
    /// <summary>
    /// Контроллер для работника
    /// </summary>
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

        /// <summary>
        /// Метод для получение всех работников
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpGet(nameof(GetAll))]
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            ICollection<Worker> workers = await _workerService.GetAllAsync(token);
            ICollection<WorkerDTO> workerDTOs = _mapper.Map<ICollection<WorkerDTO>>(workers);
            return Ok(workerDTOs);
        }

        /// <summary>
        /// Метод для получения работника по его Id
        /// </summary>
        /// <param name="id">Id работника</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpGet(nameof(Get))]
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> Get([FromQuery]long id, CancellationToken token)
        {
            Worker? worker = await _workerService.GetAsync(id, token);
            WorkerDTO? workerDTO = _mapper.Map<WorkerDTO>(worker);
            return Ok(workerDTO);
        }

        /// <summary>
        /// Метод для обновления данных работника
        /// </summary>
        /// <param name="workerDTO">Параметры работника</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpPut(nameof(Update))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Update([FromBody]WorkerDTO workerDTO, CancellationToken token)
        {
            Worker worker = _mapper.Map<Worker>(workerDTO);
            Worker updatedWorker = await _workerService.UpdateAsync(worker, token);
            WorkerDTO updatedWorkerDTO = _mapper.Map<WorkerDTO>(updatedWorker);
            return Ok(updatedWorkerDTO);
        }

        /// <summary>
        /// Метод для удаления работника
        /// </summary>
        /// <param name="id">Id работника</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpDelete(nameof(Delete))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Delete([FromQuery] long id, CancellationToken token)
        {
            await _workerService.RemoveAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Метод для удаления аватара работника
        /// </summary>
        /// <param name="id">Id работника</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpDelete(nameof(RemoveAvatar))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> RemoveAvatar([FromQuery] long id, CancellationToken token)
        {
            await _workerService.RemoveAvatarAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Метод для загрузки аватара работника
        /// </summary>
        /// <param name="workerId">Id работника</param>
        /// <param name="file">Название файла</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
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

        /// <summary>
        /// Метод для получения аватара работника
        /// </summary>
        /// <param name="workerId">Id работника</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
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
