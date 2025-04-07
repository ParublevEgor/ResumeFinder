﻿using ResumeFinder.Domain.Models.Enums;

namespace ResumeFinder.Domain.Models
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

        public Guid? ImageUUID { get; set; }

        public ICollection<Resume> Resumes { get; set; }
    }
}
