using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static Jobsearch_backend.Models.JobAllowablePatchFields;
using Jobsearch_backend.Data;
using Jobsearch_backend.Models;
using Jobsearch_backend.Exceptions; // If JobDto is in the Models namespace

namespace Jobsearch_backend.Services
{
    public class JobService(JobsearchDbContext dbContext) : IJobService
    {
        private readonly JobsearchDbContext _dbContext = dbContext;

        public bool WriteJob( Job job, string fieldName, object fieldValue)
        {
            var propertyInfo = job.GetType().GetProperty(fieldName);
            if ( propertyInfo != null && propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(job, fieldValue, null);
                return true;
            }
            else
            {
                return false;
            }
        }

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

        public async Task<string> PatchJobAsync(int jobId, Dictionary<string, object> patchData)
        {
            var job = await _dbContext.Jobs.FindAsync(jobId) ?? throw new NotFoundException("Job not found");
            foreach (var item in patchData)
            {
                if (!ValidFieldAndData(item.Key, item.Value)) // Directly calling the method
                {
                    throw new ValidationException($"Invalid field or data type for field '{item.Key}'");
                }

                if (!WriteJob(job, item.Key, item.Value))
                {
                    throw new ValidationException($"Unable to update field '{item.Key}'");
                }
            }

            await _dbContext.SaveChangesAsync();

            return "Update successful";
        }

    }
}
