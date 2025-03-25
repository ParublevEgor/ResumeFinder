using Microsoft.EntityFrameworkCore;
using ResumeFinder.Entities;
using System.Reflection;

namespace ResumeFinder.Repositories
{
    public class ResumeFinderContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Resume> Resumes { get; set; }

        public DbSet<WorkPlace> WorkPlaces { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public ResumeFinderContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }
    }
}
