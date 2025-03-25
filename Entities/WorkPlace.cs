using ResumeFinder.Entities.Enums;

namespace ResumeFinder.Entities
{
    public class WorkPlace : IEntity
    {
        public long Id { get; set; }

        public string CompanyName { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; }

        public long SpecializationId { get; set; }

        public Specialization Specialization { get; set; }

        public string Description { get; set; }

        public long ResumeId { get; set; }

        public Level Level { get; set; }
    }
}
