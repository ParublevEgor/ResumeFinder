using ResumeFinder.Domain.Models;

namespace ResumeFinder.DTO
{
    public class CustomerDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public long UserId { get; set; }
    }
}
