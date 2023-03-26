﻿using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Repositories.Contracts
{
    public interface ICoursesRepository
    {
        Task<IReadOnlyCollection<Course>> GetAllAsync();
        Task<Course> GetAsync(Guid id);
        Task CreateAsync(Course course);
        Task UpdateAsync(Course course);
        Task RemoveAsync(Guid id);
    }
}
