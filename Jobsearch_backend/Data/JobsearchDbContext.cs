namespace Jobsearch_backend.Data
{
    using Jobsearch_backend.Models;
    using Microsoft.EntityFrameworkCore;

    public class JobsearchDbContext(DbContextOptions<JobsearchDbContext> options) : DbContext(options)
    {
        public DbSet<Job> Jobs { get; set; }

        // Other DbSet properties for other tables
    }

}
