using Jobsearch_backend.Data; // Replace with the correct namespace
using System.Diagnostics;


namespace Jobsearch_backend.Tests
{
    public class DatabaseConnectivityTests
    {
        private readonly JobsearchDbContext _dbContext;

        public DatabaseConnectivityTests(JobsearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<int> TestDatabaseConnection()
        {
            Debug.WriteLine("TestDatabaseConnection");
            var jobs = _dbContext.Jobs.Select(j => j.JobId).Take(10).ToList();
            if (!jobs.Any())
            {
                Debug.WriteLine("No jobs found.");
                return new List<int>();
            }
            else
            {
                return jobs;
            }
        }
    }
}
