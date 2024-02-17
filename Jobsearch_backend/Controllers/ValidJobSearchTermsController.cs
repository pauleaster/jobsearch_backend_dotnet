using Jobsearch_backend.Exceptions;
using Jobsearch_backend.Models;
using Jobsearch_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Jobsearch_backend.Controllers
{
    [ApiController]
    public class ValidJobSearchTermsController(IValidJobSearchTermsService validJobSearchTermsService) : ControllerBase
    {
        private readonly IValidJobSearchTermsService _validJobSearchTermsService = validJobSearchTermsService;


        [HttpGet("api/validJobsAndSearchTerms")]
        public async Task<IActionResult> GetValidJobSearchTerms()
        {
            var validJobSearchTerms = await _validJobSearchTermsService.GetValidJobSearchTermsAsync();
            //Debug.WriteLine(validJobSearchTerms);
            return Ok(validJobSearchTerms);
        }

        [HttpPost("api/filteredJobsAndSearchTerms")]
        public async Task<IActionResult> GetFilteredValidJobSearchTermsAsync([FromBody] FilterTermsRequestDto requestDto)
        {
            //Debug.WriteLine(requestDto.ToString());
            var searchTermString = new SearchTermString { Terms = requestDto.FilterTerms };
            bool? currentJobs = requestDto.CurrentJobs;
            bool? appliedJobs = requestDto.AppliedJobs;

            // Pass searchTermString, currentJobs, and appliedJobs to the service method
            var validJobSearchTerms = await _validJobSearchTermsService.GetFilteredValidJobSearchTermsAsync(searchTermString, currentJobs, appliedJobs);

            return Ok(validJobSearchTerms);
        }


    }
}
