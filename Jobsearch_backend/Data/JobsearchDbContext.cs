namespace Jobsearch_backend.Data
{
    using Jobsearch_backend.Models;
    using Microsoft.EntityFrameworkCore;

    public class JobsearchDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<SearchTerm> SearchTerms { get; set; }
        // public DbSet<JobSearchTerm> JobSearchTerm { get; set; }

        public JobsearchDbContext(DbContextOptions<JobsearchDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the SearchTerm entity to use the 'search_terms' table
            modelBuilder.Entity<SearchTerm>().ToTable("search_terms");
        }
    }
}
