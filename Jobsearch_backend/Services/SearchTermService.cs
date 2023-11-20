using System.Diagnostics;
using Jobsearch_backend.Data;
using Jobsearch_backend.Models;
using Microsoft.EntityFrameworkCore;


namespace Jobsearch_backend.Services
{
    public class SearchTermService(JobsearchDbContext dbContext) : ISearchTermService
    {
        private readonly JobsearchDbContext _dbContext = dbContext;

        public async Task<SearchTermDto?> GetSearchTermByIdAsync(int SearchTermId)
        {

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
        }

        public async Task<List<string>> GetSearchTermsAsync()
        {
            List<string> results = await _dbContext.SearchTerms
                            .OrderBy(searchTerm => searchTerm.SearchTermText)
                            .Select(searchTerm => searchTerm.SearchTermText)
                            .ToListAsync();
            Debug.WriteLine(results);
            return results;
        }

        public async Task<SearchTermString> GetCombinedSearchTermsAsync()
        {
            var searchTermsList = await GetSearchTermsAsync();
            var combinedSearchTerms = new SearchTermString();

            foreach (var termsString in searchTermsList)
            {
                combinedSearchTerms.AddTermsFromString(termsString);
            }

            return combinedSearchTerms;
        }


    }
}
