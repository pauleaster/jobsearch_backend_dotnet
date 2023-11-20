using Jobsearch_backend.Exceptions;
using Jobsearch_backend.Models;
using Jobsearch_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Jobsearch_backend.Controllers
{
    [ApiController]
    [Route("api/validJobsAndSearchTerms")]
    public class ValidJobSearchTermsController(IValidJobSearchTermsService validJobSearchTermsService) : ControllerBase
    {
        private readonly IValidJobSearchTermsService _validJobSearchTermsService = validJobSearchTermsService;

        
        [HttpGet]
        public async Task<IActionResult> GetValidSearchTerms()
        {
            var validJobSearchTerms = await _validJobSearchTermsService.GetValidJobSearchTermsAsync();
            Debug.WriteLine(validJobSearchTerms);
            return Ok(validJobSearchTerms);
        }

        ////[Route("api/SearchTerms")]
        //[HttpGet]
        //public async Task<IActionResult> GetSearchTerms()
        //{
        //    var searchTerms = await _searchTermService.GetSearchTermsAsync();
        //    Debug.WriteLine(searchTerms);
        //    return Ok(searchTerms);
        //}


    }
}
