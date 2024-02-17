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

        public async Task<List<ValidJobSearchTermDto>> GetFilteredValidJobSearchTermsAsync(SearchTermString searchTermString, bool? currentJobs = null, bool? appliedJobs = null)
        {

            if (searchTermString.IsEmpty)
            {
                // If searchTermString is empty, fetch combined search terms
                searchTermString = await _searchTermService.GetCombinedSearchTermsAsync();
            }

            const char Delimiter = '|';
            string searchTerms = searchTermString.ToDelimitedString(Delimiter);
            Debug.WriteLine($"\n\nsearchTerms: {searchTerms}\n\n");

            var query = from j in _dbContext.Jobs
                        join jst in _dbContext.JobSearchTerms on j.JobId equals jst.JobId
                        join st in _dbContext.SearchTerms on jst.SearchTermId equals st.SearchTermId
                        where jst.Valid && searchTerms.Contains(Delimiter + st.SearchTermText + Delimiter)
                        select new { j, jst, st };

            if (currentJobs.HasValue)
            {
                if (currentJobs.Value)
                {
                    // If currentJobs is true, exclude jobs with comments indicating they are no longer advertised,
                    // and also consider jobs where Comments is null as current.
                    query = query.Where(x => x.j.Comments == null ||
                                             !(x.j.Comments.Contains("no") 
                                                && x.j.Comments.Contains("longer") 
                                                && x.j.Comments.Contains("advertised")));
                }
                else
                {
                    // If currentJobs is false, include only jobs with comments indicating they are no longer advertised,
                    // this implicitly excludes jobs where Comments is null.
                    query = query.Where(x => x.j.Comments != null &&
                                             x.j.Comments.Contains("no") 
                                                && x.j.Comments.Contains("longer") 
                                                && x.j.Comments.Contains("advertised"));
                }
            }


            if (appliedJobs.HasValue)
            {
                if (appliedJobs.Value)
                {
                    // If appliedJobs is true, include only jobs where Applied is "yes".
                    // This also excludes jobs where Applied is null.
                    query = query.Where(x => x.j.Applied != null && x.j.Applied.Contains("yes"));
                }
                else
                {
                    // If appliedJobs is false, include jobs where Applied is not "yes",
                    // including jobs where Applied is null, since null does not contain "yes".
                    query = query.Where(x => x.j.Applied == null || !x.j.Applied.Contains("yes"));
                }
            }


            var jobTerms = await query
                    .GroupBy(j => new { j.j.JobId, j.j.JobNumber })
                    .Select(g => new
                    {
                        JobId = g.Key.JobId,
                        JobNumber = g.Key.JobNumber,
                        MatchingSearchTerms = string.Join(", ", g.Select(x => x.st.SearchTermText).ToList())
                    })
                    .ToListAsync();

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
