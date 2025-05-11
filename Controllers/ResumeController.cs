using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.DTO;
using ResumeFinder.DTO.Requests;
using ResumeFinder.Services;

namespace ResumeFinder.Controllers
{
    /// <summary>
    /// Контроллер для резюме
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ResumeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IResumeService _resumeService;

        public ResumeController(IResumeService resumeService, IMapper mapper)
        {
            _resumeService = resumeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод для получения всех резюме
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpGet(nameof(GetAll))]
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            ICollection<Resume> resumes = await _resumeService.GetAllAsync(token);
            ICollection<ResumeDTO> resumeDTOs = _mapper.Map<ICollection<ResumeDTO>>(resumes);
            return Ok(resumeDTOs);
        }

        /// <summary>
        /// Метод для получения резюме по Id
        /// </summary>
        /// <param name="id">Id резюме</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpGet(nameof(Get))]
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> Get([FromQuery] long id, CancellationToken token)
        {
            Resume? resume = await _resumeService.GetAsync(id, token);
            ResumeDTO? resumeDTO = _mapper.Map<ResumeDTO>(resume);
            return Ok(resumeDTO);
        }

        /// <summary>
        /// Метод для получения резюме работника
        /// </summary>
        /// <param name="userId">Id работника</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpGet(nameof(GetByUser))]
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> GetByUser([FromQuery] long userId, CancellationToken token)
        {
            ICollection<Resume> resumes = await _resumeService.GetByUserAsync(userId, token);
            ICollection<ResumeDTO> resumeDTOs = _mapper.Map<ICollection<ResumeDTO>>(resumes);
            return Ok(resumeDTOs);
        }

        /// <summary>
        /// Метод для удаления резюме
        /// </summary>
        /// <param name="id">Id резюме</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpDelete(nameof(Delete))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Delete([FromQuery] long id, CancellationToken token)
        {
            await _resumeService.RemoveAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Метод для добавления резюме
        /// </summary>
        /// <param name="resumeDTO">Данные резюме</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpPost(nameof(Add))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Add([FromBody] ResumeDTO resumeDTO, CancellationToken token)
        {
            Resume resume = _mapper.Map<Resume>(resumeDTO);
            Resume addedResume = await _resumeService.AddAsync(resume, token);
            ResumeDTO addedResumeDTO = _mapper.Map<ResumeDTO>(addedResume);
            return Ok(addedResumeDTO);
        }

        /// <summary>
        /// Метод для обновления резюме
        /// </summary>
        /// <param name="resumeRequest">Данные резюме</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpPut(nameof(Update))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Update([FromBody] UpdateResumeRequest resumeRequest, CancellationToken token)
        {
            Resume resume = _mapper.Map<Resume>(resumeRequest);
            Resume updatedResume = await _resumeService.UpdateAsync(resume, token);
            ResumeDTO updatedResumeDTO = _mapper.Map<ResumeDTO>(updatedResume);
            return Ok(updatedResumeDTO);
        }
    }
}
