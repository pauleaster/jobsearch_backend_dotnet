using System.Diagnostics;
using Jobsearch_backend.Data;
using Jobsearch_backend.Models;
using Jobsearch_backend.Exceptions; // If JobDto is in the Models namespace

namespace Jobsearch_backend.Services
{
    public class JobService(JobsearchDbContext dbContext) : IJobService
    {
        private readonly JobsearchDbContext _dbContext = dbContext;

        public async Task<JobDto?> GetJobByIdAsync(int JobId)
        {
            // Implementation to retrieve a job by its ID
            // Example:
            Job? job = await _dbContext.Jobs.FindAsync(JobId);
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
            };
            Debug.WriteLine(jobDto);
            return jobDto;
        }
        public async Task<string?> GetJobHtmlDataByIdAsync(int JobId)
        {
            // Implementation to retrieve a job by its ID
            // Example:
            Job? job = await _dbContext.Jobs.FindAsync(JobId);
            if (job == null) return null;


            return job?.JobHtml;
        }

        public async Task<string> PatchJobAsync(int jobId, JobPatchDto patchData)
        {
            var job = await _dbContext.Jobs.FindAsync(jobId) ?? throw new NotFoundException("Job not found");

            if (patchData.Title != null)
            {
                job.Title = patchData.Title;
            }
            if (patchData.Comments != null)
            {
                job.Comments = patchData.Comments;
            }
            if (patchData.Requirements != null)
            {
                job.Requirements = patchData.Requirements;
            }
            if (patchData.FollowUp != null)
            {
                job.FollowUp = patchData.FollowUp;
            }
            if (patchData.Highlight != null)
            {
                job.Highlight = patchData.Highlight;
            }
            if (patchData.Applied != null)
            {
                job.Applied = patchData.Applied;
            }
            if (patchData.Contact != null)
            {
                job.Contact = patchData.Contact;
            }
            if (patchData.ApplicationComments != null)
            {
                job.ApplicationComments = patchData.ApplicationComments;
            }


            await _dbContext.SaveChangesAsync();

            return "Update successful";
        }

    }
}
