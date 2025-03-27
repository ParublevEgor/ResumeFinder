namespace ResumeFinder.Domain.Models
{
    public class Resume : IEntity
    {
        public long Id { get; set; }

        public long WorkerId { get; set; }

        public Worker Worker { get; set; }

        public string Name { get; set; }

        public ICollection<WorkPlace> WorkPlaces { get; set; }
    }
}
