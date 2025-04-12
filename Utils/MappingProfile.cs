using AutoMapper;
using ResumeFinder.Domain.Models;
using ResumeFinder.DTO;
using ResumeFinder.DTO.Requests;

namespace ResumeFinder.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Worker, WorkerDTO>().ReverseMap();
            CreateMap<Resume, ResumeDTO>().ReverseMap();
            CreateMap<WorkPlace, ResumeWorkPlaceDTO>().ReverseMap();
            CreateMap<Specialization, SpecializationDTO>().ReverseMap();
            CreateMap<UpdateResumeRequest, Resume>();
            CreateMap<WorkPlace, WorkPlaceDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
