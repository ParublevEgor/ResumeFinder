﻿using ResumeFinder.Domain.Models;

namespace ResumeFinder.Domain.Storage
{
    public interface IResumeRepository : IBaseRepository<Resume>
    {
        Task<ICollection<Resume>> GetByUserAsync(long userId, CancellationToken token);
    }
}
