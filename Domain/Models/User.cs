using ResumeFinder.Domain.Models.Enums;

namespace ResumeFinder.Domain.Models
{
    public class User : IEntity
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public Role Role { get; set; }
    }
}
