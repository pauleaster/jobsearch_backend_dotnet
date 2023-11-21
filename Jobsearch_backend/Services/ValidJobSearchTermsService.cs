using System.Diagnostics;
using Jobsearch_backend.Data;
using Jobsearch_backend.Models;
using Jobsearch_backend.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens; // If JobDto is in the Models namespace

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
            const char Delimiter = '|';
            string searchTerms = searchTermString.ToDelimitedString(Delimiter);
            //Debug.WriteLine($"\n\nsearchTerms: {searchTerms}\n\n");

            var jobTerms = await (from j in _dbContext.Jobs
                                  join jst in _dbContext.JobSearchTerms on j.JobId equals jst.JobId
                                  join st in _dbContext.SearchTerms on jst.SearchTermId equals st.SearchTermId
                                  where jst.Valid && searchTerms.Contains(Delimiter + st.SearchTermText + Delimiter)
                                  group st.SearchTermText by new { j.JobId, j.JobNumber } into g
                                  select new
                                  {
                                      JobId = g.Key.JobId,
                                      JobNumber = g.Key.JobNumber,
                                      MatchingSearchTerms = string.Join(", ", g.ToList())
                                  }).ToListAsync();

            var sortedJobTerms = jobTerms
                .OrderByDescending(jt => jt.MatchingSearchTerms.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length)
                .Select(jt => new ValidJobSearchTermDto
                {
                    JobId = jt.JobId,
                    JobNumber = jt.JobNumber,
                    MatchingSearchTerms = string.Join(", ", jt.MatchingSearchTerms
                                                            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                            .Select(term => term.Trim())
                                                            .OrderBy(term => term))
                })
                .ToList();

            //Debug.WriteLine(sortedJobTerms);

            return sortedJobTerms;
        }

    }
}
