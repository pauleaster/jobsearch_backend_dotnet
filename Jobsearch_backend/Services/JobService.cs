using System.Diagnostics;
using Jobsearch_backend.Data;
using Jobsearch_backend.Models; // If JobDto is in the Models namespace

namespace Jobsearch_backend.Services
{
    public class JobService : IJobService
    {
        private readonly JobsearchDbContext _dbContext;

        public JobService(JobsearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<JobDto?> GetJobByIdAsync(int id)
        {
            // Implementation to retrieve a job by its ID
            // Example:
            var job = await _dbContext.Jobs.FindAsync(id);
            if (job == null) return null;

            // Map the job entity to JobDto
            var jobDto = new JobDto
            {
                JobId = job.JobId,
                JobNumber = job.JobNumber,
                JobUrl = job.JobUrl,
                Title = job.Title,
                Comments = job.Comments,
                Requirements = job.Requirements,
                FollowUp = job.FollowUp,
                Highlight = job.Highlight,
                Applied = job.Applied,
                Contact = job.Contact,
                ApplicationComments = job.ApplicationComments,
                // ... map other properties ...
            };
            Debug.WriteLine(jobDto);
            return jobDto;
        }
    }
}
