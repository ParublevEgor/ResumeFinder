using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.DTO;
using ResumeFinder.Services;
using System.Diagnostics.Contracts;

namespace ResumeFinder.Controllers
{
    /// <summary>
    /// Контроллер для мест работы
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WorkPlaceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWorkPlaceService _workplaceService;

        public WorkPlaceController(IWorkPlaceService workplaceService, IMapper mapper)
        {
            _workplaceService = workplaceService;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод для добавления мест работы
        /// </summary>
        /// <param name="workplaceDTO">Параметры мест работы</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpPost(nameof(Add))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Add([FromBody] WorkPlaceDTO workplaceDTO, CancellationToken token)
        {
            WorkPlace workPlace = _mapper.Map<WorkPlace>(workplaceDTO);
            WorkPlace addedWorkPlace = await _workplaceService.AddAsync(workPlace, token);
            WorkPlaceDTO addedWorkPlaceDTO = _mapper.Map<WorkPlaceDTO>(addedWorkPlace);
            return Ok(addedWorkPlaceDTO);
        }

        /// <summary>
        /// Метод для обновления мест работы
        /// </summary>
        /// <param name="workplaceDTO">Параметры мест работы</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpPut(nameof(Update))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Update([FromBody] WorkPlaceDTO workplaceDTO, CancellationToken token)
        {
            WorkPlace workPlace = _mapper.Map<WorkPlace>(workplaceDTO);
            WorkPlace updatedWorkPlace = await _workplaceService.UpdateAsync(workPlace, token);
            WorkPlaceDTO updatedWorkPlaceDTO = _mapper.Map<WorkPlaceDTO>(updatedWorkPlace);
            return Ok(updatedWorkPlaceDTO);
        }

        /// <summary>
        /// Метод для удаления мест работы
        /// </summary>
        /// <param name="id">Id работника</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Состояние запроса</returns>
        [HttpDelete(nameof(Delete))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Delete([FromQuery] long id, CancellationToken token)
        {
            await _workplaceService.RemoveAsync(id, token);
            return Ok();
        }
    }
}
