using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.DTO;
using ResumeFinder.Services;

namespace ResumeFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IResumeService _resumeService;

        public ResumeController(IResumeService resumeService, IMapper mapper)
        {
            _resumeService = resumeService;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            ICollection<Resume> resumes = await _resumeService.GetAllAsync(token);
            ICollection<ResumeDTO> resumeDTOs = _mapper.Map<ICollection<ResumeDTO>>(resumes);
            return Ok(resumeDTOs);
        }

        [HttpGet(nameof(Get))]
        public async Task<IActionResult> Get([FromQuery] long id, CancellationToken token)
        {
            Resume? resume = await _resumeService.GetAsync(id, token);
            ResumeDTO? resumeDTO = _mapper.Map<ResumeDTO>(resume);
            return Ok(resumeDTO);
        }

        [HttpGet(nameof(GetByUser))]
        public async Task<IActionResult> GetByUser([FromQuery] long userId, CancellationToken token)
        {
            ICollection<Resume> resumes = await _resumeService.GetByUserAsync(userId, token);
            ICollection<ResumeDTO> resumeDTOs = _mapper.Map<ICollection<ResumeDTO>>(resumes);
            return Ok(resumeDTOs);
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete([FromQuery] long id, CancellationToken token)
        {
            await _resumeService.RemoveAsync(id, token);
            return Ok();
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] ResumeDTO resumeDTO, CancellationToken token)
        {
            Resume resume = _mapper.Map<Resume>(resumeDTO);
            Resume addedResume = await _resumeService.AddAsync(resume, token);
            ResumeDTO addedResumeDTO = _mapper.Map<ResumeDTO>(addedResume);
            return Ok(addedResumeDTO);
        }
    }
}
