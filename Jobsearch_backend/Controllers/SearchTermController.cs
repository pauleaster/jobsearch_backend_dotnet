using Jobsearch_backend.Exceptions;
using Jobsearch_backend.Models;
using Jobsearch_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Jobsearch_backend.Controllers
{
    [ApiController]
    public class SearchTermController(ISearchTermService searchTermService) : ControllerBase
    {
        private readonly ISearchTermService _searchTermService = searchTermService;


        [HttpGet("api/SearchTerm/{SearchTermId}")]
        public async Task<IActionResult> GetSearchTerm(int SearchTermId)
        {
            var searchTerm = await _searchTermService.GetSearchTermByIdAsync(SearchTermId);
            if (searchTerm == null)
            {
                return NotFound();
            }
            //Debug.WriteLine(searchTerm);
            return Ok(searchTerm);
        }

        [HttpGet("api/SearchTerms")]
        public async Task<IActionResult> GetSearchTerms()
        {
            var searchTerms = await _searchTermService.GetSearchTermsAsync();
            //Debug.WriteLine(searchTerms);
            return Ok(searchTerms);
        }


    }
}
