using ResumeFinder.Domain.Models.Enums;

namespace ResumeFinder.Domain.Models
{
    public class Customer : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
    }
}
