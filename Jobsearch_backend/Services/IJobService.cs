using Jobsearch_backend.Models; // If JobDto is in the Models namespace

namespace Jobsearch_backend.Services
{
    public interface IJobService
    {
        Task<JobDto?> GetJobByIdAsync(int id);
        Task<string?> GetJobHtmlDataByIdAsync(int id);
        Task<string> PatchJobAsync(int JobId, JobPatchDto patchData);
    }
}
