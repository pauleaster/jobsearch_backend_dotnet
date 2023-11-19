using Jobsearch_backend.Models; // If JobDto is in the Models namespace

namespace Jobsearch_backend.Services
{
    public interface ISearchTermService
    {
        Task<SearchTermDto?> GetSearchTermByIdAsync(int SearchTermId);

    }
}
