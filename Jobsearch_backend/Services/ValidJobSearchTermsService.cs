using System.Diagnostics;
using Jobsearch_backend.Data;
using Jobsearch_backend.Models;
using Jobsearch_backend.Exceptions;
using Microsoft.EntityFrameworkCore; // If JobDto is in the Models namespace

namespace Jobsearch_backend.Services
{
    public class ValidJobSearchTermsService(JobsearchDbContext dbContext, ISearchTermService searchTermService) : IValidJobSearchTermsService
    {
        private readonly JobsearchDbContext _dbContext = dbContext;
        private readonly ISearchTermService _searchTermService = searchTermService;

        public async Task<List<ValidJobSearchTermDto>> GetValidJobSearchTermsAsync()
        {
            SearchTermString allSearchTerms = await _searchTermService.GetCombinedSearchTermsAsync();
            List<ValidJobSearchTermDto> validJobSearchTerms = await GetFilteredValidJobSearchTermsAsync(allSearchTerms);
            return validJobSearchTerms;

        }

        public async Task<List<ValidJobSearchTermDto>> GetFilteredValidJobSearchTermsAsync(SearchTermString searchTermString)
        {

            var validJobTerms = from j in _dbContext.Jobs
                                join jst in _dbContext.JobSearchTerms on j.JobId equals jst.JobId
                                join st in _dbContext.SearchTerms on jst.SearchTermId equals st.SearchTermId
                                where jst.Valid
                                select new
                                {
                                    j.JobId,
                                    j.JobNumber,
                                    st.SearchTermText
                                };

            var filteredJobTerms = from vjt in validJobTerms
                                   where searchTermString.Contains(vjt.SearchTermText)
                                   select new ValidJobSearchTermDto
                                   {
                                       JobId = vjt.JobId,
                                       JobNumber = vjt.JobNumber,
                                       MatchingSearchTerms = vjt.SearchTermText
                                   };

            // Execution of the query
            var filteredValidJobSearchTerms = await filteredJobTerms.ToListAsync();
            Debug.WriteLine(filteredValidJobSearchTerms);


            return filteredValidJobSearchTerms;
        }
    }
}
