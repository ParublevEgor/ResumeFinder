namespace ResumeFinder.Entities
{
    public class Resume : IEntity
    {
        public long Id { get; set; }

        public long WorkerId { get; set; }

        public Worker Worker { get; set; }

        public string Name { get; set; }

        public long SpecializationId { get; set; }

        public Specialization Specialization { get; set; }

        public ICollection<WorkPlace> WorkPlaces { get; set; }
    }
}
