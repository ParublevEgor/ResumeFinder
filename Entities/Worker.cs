using ResumeFinder.Entities.Enums;

namespace ResumeFinder.Entities
{
    public class Worker : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public Gender Gender { get; set; }

        public string Information { get; set; }

        public ICollection<Resume> Resumes { get; set; }
    }
}
