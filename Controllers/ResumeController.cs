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

        [HttpGet(nameof(GetAll))]
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            ICollection<Resume> resumes = await _resumeService.GetAllAsync(token);
            ICollection<ResumeDTO> resumeDTOs = _mapper.Map<ICollection<ResumeDTO>>(resumes);
            return Ok(resumeDTOs);
        }

        [HttpGet(nameof(Get))]
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> Get([FromQuery] long id, CancellationToken token)
        {
            Resume? resume = await _resumeService.GetAsync(id, token);
            ResumeDTO? resumeDTO = _mapper.Map<ResumeDTO>(resume);
            return Ok(resumeDTO);
        }

        [HttpGet(nameof(GetByUser))]
        [Authorize(Roles = "Customer, Worker")]
        public async Task<IActionResult> GetByUser([FromQuery] long userId, CancellationToken token)
        {
            ICollection<Resume> resumes = await _resumeService.GetByUserAsync(userId, token);
            ICollection<ResumeDTO> resumeDTOs = _mapper.Map<ICollection<ResumeDTO>>(resumes);
            return Ok(resumeDTOs);
        }

        [HttpDelete(nameof(Delete))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Delete([FromQuery] long id, CancellationToken token)
        {
            await _resumeService.RemoveAsync(id, token);
            return Ok();
        }

        [HttpPost(nameof(Add))]
        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Add([FromBody] ResumeDTO resumeDTO, CancellationToken token)
        {
            Resume resume = _mapper.Map<Resume>(resumeDTO);
            Resume addedResume = await _resumeService.AddAsync(resume, token);
            ResumeDTO addedResumeDTO = _mapper.Map<ResumeDTO>(addedResume);
            return Ok(addedResumeDTO);
        }

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
