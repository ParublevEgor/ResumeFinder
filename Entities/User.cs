using ResumeFinder.Entities.Enums;

namespace ResumeFinder.Entities
{
    public class User : IEntity
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public Role Role { get; set; }
    }
}
