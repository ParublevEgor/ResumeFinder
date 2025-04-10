﻿namespace ResumeFinder.DTO
{
    public class WorkPlaceDTO
    {
        public long Id { get; set; }

        public string CompanyName { get; set; }

        public DateTime From { get; set; }

        public DateTime? To { get; set; }

        public long SpecializationId { get; set; }

        public string Description { get; set; }

        public long ResumeId { get; set; }

        public string Level { get; set; }
    }
}
