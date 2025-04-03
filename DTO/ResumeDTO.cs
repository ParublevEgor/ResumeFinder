using ResumeFinder.Domain.Models;

namespace ResumeFinder.DTO
{
    public class ResumeDTO
    {
        public long Id { get; set; }

        public long WorkerId { get; set; }

        public string Name { get; set; }

        public List<WorkPlaceDTO> WorkPlaces { get; set; }
    }
}
