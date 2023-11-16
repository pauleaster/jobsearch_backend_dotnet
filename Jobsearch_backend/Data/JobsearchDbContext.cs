namespace Jobsearch_backend.Data
{
    using Jobsearch_backend.Models;
    using Microsoft.EntityFrameworkCore;

    public class JobsearchDbContext : DbContext
    {
        public JobsearchDbContext(DbContextOptions<JobsearchDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }

        // Other DbSet properties for other tables
    }

}
