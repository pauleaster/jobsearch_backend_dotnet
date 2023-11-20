using System.Diagnostics;
using Jobsearch_backend.Data;
using Jobsearch_backend.Models;


namespace Jobsearch_backend.Services
{
    public class JobSearchTermService(JobsearchDbContext dbContext) : IJobSearchTermService
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly JobsearchDbContext _dbContext = dbContext;
#pragma warning restore IDE0052 // Remove unread private members

        /*public async Task<SearchTermDto?> GetSearchTermByIdAsync(int SearchTermId)
        {
            // Implementation to retrieve a job by its ID
            // Example:
            SearchTerm? searchTerm = await _dbContext.SearchTerms.FindAsync(SearchTermId);
            if (searchTerm == null) return null;

            // Map the searchTerm entity to SearchTermDto
            var searchTermDto = new SearchTermDto
            {
                SearchTermId = searchTerm.SearchTermId,
                SearchTermText = searchTerm.SearchTermText,
            };
            Debug.WriteLine(searchTermDto);
            return searchTermDto;
        }*/


    }
}
