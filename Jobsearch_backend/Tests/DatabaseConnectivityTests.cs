using Jobsearch_backend.Data; // Replace with the correct namespace

namespace Jobsearch_backend.Tests
{
    public class DatabaseConnectivityTests
    {
        private readonly JobsearchDbContext _dbContext;

        public DatabaseConnectivityTests(JobsearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void TestDatabaseConnection()
        {
            var jobs = _dbContext.Jobs.Select(j => j.JobId).ToList();
            foreach (var jobId in jobs)
            {
                Console.WriteLine(jobId);
            }
        }
    }
}
