namespace Jobsearch_backend.Data
{
    using Jobsearch_backend.Models;
    using Microsoft.EntityFrameworkCore;

    public class JobsearchDbContext(DbContextOptions<JobsearchDbContext> options) : DbContext(options)
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<SearchTerm> SearchTerms { get; set; }
        public DbSet<JobSearchTerm> JobSearchTerms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the SearchTerm entity to use the 'search_terms' and 'job_search_terms' table
            modelBuilder.Entity<SearchTerm>().ToTable("search_terms");
            modelBuilder.Entity<JobSearchTerm>()
                .ToTable("job_search_terms")
                .HasKey(jst => new { jst.JobId, jst.SearchTermId });
        }

    }
}
