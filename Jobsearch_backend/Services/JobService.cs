using System.Diagnostics;
using Jobsearch_backend.Data;
using Jobsearch_backend.Models;
using Jobsearch_backend.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Globalization; // If JobDto is in the Models namespace

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
                JobDate = job.JobDate,
                ApplicationDate = job.ApplicationDate,
                Unsuccessful = job.Unsuccessful,
            };
            //Debug.WriteLine(jobDto);
            return jobDto;
        }

        public async Task<string> PatchJobAsync(int jobId, JobPatchFieldDto patchData)
        {
            var job = await _dbContext.Jobs.FindAsync(jobId) ?? throw new NotFoundException("Job not found");

            Debug.WriteLine("PatchJobAsync: patchData is\n" + patchData);

            switch (patchData.Field)
            {           
                case "Title":
                    job.Title = patchData.Value;
                    break;
                case "Comments":
                    job.Comments = patchData.Value;
                    break;
                case "Requirements":
                    job.Requirements = patchData.Value;
                    break;
                case "Follow Up":
                    job.FollowUp = patchData.Value;
                    break;
                case "Highlight":
                    job.Highlight = patchData.Value;
                    break;
                case "Applied":
                    job.Applied = patchData.Value;
                    break;
                case "Contact":
                    job.Contact = patchData.Value;
                    break;
                case "Application Comments":
                    job.ApplicationComments = patchData.Value;
                    break;
                case "Job Date":
                    if (DateTime.TryParse(patchData.Value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out DateTime jobDate))
                    {
                        job.JobDate = jobDate;
                    }
                    else
                    {
                        throw new ValidationException("Invalid JobDate format");
                    }
                    break;
                case "Application Date":
                    if (DateTime.TryParse(patchData.Value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out DateTime applicationDate))
                    {
                        job.ApplicationDate = applicationDate;
                    }
                    else
                    {
                        throw new ValidationException("Invalid ApplicationDate format");
                    }
                    break;
                case "Unsuccessful":
                    job.Unsuccessful = patchData.Value;
                    break;
                default:
                    throw new ValidationException("Invalid field name");
            }

            
            Debug.WriteLine("PatchJobAsync: updating job to\n" + job);
            await _dbContext.SaveChangesAsync();
            Debug.WriteLine("PatchJobAsync: _dbContext.SaveChangesAsync() complete");

            return "Update successful";
        }

    }
}
