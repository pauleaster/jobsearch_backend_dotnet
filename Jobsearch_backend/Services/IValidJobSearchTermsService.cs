using Jobsearch_backend.Models; // If JobDto is in the Models namespace

namespace Jobsearch_backend.Services
{
    public interface IValidJobSearchTermsService
    {
        Task<List<ValidJobSearchTermDto>> GetValidJobSearchTermsAsync();

        Task<List<ValidJobSearchTermDto>> GetFilteredValidJobSearchTermsAsync(SearchTermString searchTerms, bool? currentJobs, bool ? appliedJobs);

    }
}
