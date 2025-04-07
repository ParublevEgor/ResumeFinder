using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.DTO;
using ResumeFinder.Services;
using System.Diagnostics.Contracts;

namespace ResumeFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkPlaceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWorkPlaceService _workplaceService;

        public WorkPlaceController(IWorkPlaceService workplaceService, IMapper mapper)
        {
            _workplaceService = workplaceService;
            _mapper = mapper;
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] WorkPlaceDTO workplaceDTO, CancellationToken token)
        {
            WorkPlace workPlace = _mapper.Map<WorkPlace>(workplaceDTO);
            WorkPlace addedWorkPlace = await _workplaceService.AddAsync(workPlace, token);
            WorkPlaceDTO addedWorkPlaceDTO = _mapper.Map<WorkPlaceDTO>(addedWorkPlace);
            return Ok(addedWorkPlaceDTO);
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] WorkPlaceDTO workplaceDTO, CancellationToken token)
        {
            WorkPlace workPlace = _mapper.Map<WorkPlace>(workplaceDTO);
            WorkPlace updatedWorkPlace = await _workplaceService.UpdateAsync(workPlace, token);
            WorkPlaceDTO updatedWorkPlaceDTO = _mapper.Map<WorkPlaceDTO>(updatedWorkPlace);
            return Ok(updatedWorkPlaceDTO);
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete([FromQuery] long id, CancellationToken token)
        {
            await _workplaceService.RemoveAsync(id, token);
            return Ok();
        }
    }
}
