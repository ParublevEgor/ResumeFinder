using AutoMapper;
using ResumeFinder.Domain.Models;
using ResumeFinder.DTO;

namespace ResumeFinder.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Worker, WorkerDTO>().ReverseMap();
        }
    }
}
