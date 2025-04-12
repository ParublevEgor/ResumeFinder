using ResumeFinder.Domain.Models.Enums;
using ResumeFinder.Domain.Models;

namespace ResumeFinder.DTO
{
    public class WorkerDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public long UserId { get; set; }

        public string Gender { get; set; }

        public string Information { get; set; }

        public Guid? ImageUUID { get; set; }
    }
}
