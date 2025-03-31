using ResumeFinder.Domain.Models.Enums;

namespace ResumeFinder.Services.Params
{
    public struct RegisterWorkerParams
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public string Information { get; set; }
    }
}
