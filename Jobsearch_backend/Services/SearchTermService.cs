using System.Diagnostics;
using Jobsearch_backend.Data;
using Jobsearch_backend.Models;


namespace Jobsearch_backend.Services
{
    public class SearchTermService(JobsearchDbContext dbContext) : ISearchTermService
    {
        private readonly JobsearchDbContext _dbContext = dbContext;

        public async Task<SearchTermDto?> GetSearchTermByIdAsync(int SearchTermId)
        {
            // Implementation to retrieve a job by its ID
            // Example:
            SearchTerm? searchTerm = await _dbContext.SearchTerm.FindAsync(SearchTermId);
            if (searchTerm == null) return null;

            // Map the searchTerm entity to SearchTermDto
            var searchTermDto = new SearchTermDto
            {
                TermId = searchTerm.TermId,
                TermText = searchTerm.TermText,
            };
            Debug.WriteLine(searchTermDto);
            return searchTermDto;
        }
        

    }
}
