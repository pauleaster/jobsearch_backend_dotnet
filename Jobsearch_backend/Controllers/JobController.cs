using Jobsearch_backend.Exceptions;
using Jobsearch_backend.Models;
using Jobsearch_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Jobsearch_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController(IJobService jobService) : ControllerBase
    {
        private readonly IJobService _jobService = jobService;

        [HttpGet("{JobId}")]
        public async Task<IActionResult> GetJob(int JobId)
        {
            var job = await _jobService.GetJobByIdAsync(JobId);
            if (job == null)
            {
                return NotFound();
            }
            //Debug.WriteLine(job);
            return Ok(job);
        }

        [HttpGet("{JobId}/html")]
        public async Task<IActionResult> GetJobHtmlData(int JobId)
        {
            var jobHtml = await _jobService.GetJobHtmlDataByIdAsync(JobId);
            if (jobHtml == null)
            {
                return NotFound();
            }
            //Debug.WriteLine(jobHtml);
            return Content(jobHtml, "text/html");
        }

        [HttpPatch("{JobId}")]
        public async Task<IActionResult> PatchJob(int JobId, [FromBody] JobPatchFieldDto jobPatchFieldDto)
        {
            try
            {
                string resultMessage = await _jobService.PatchJobAsync(JobId, jobPatchFieldDto);
                var result = new { message = resultMessage };
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Generic error handling
                return StatusCode(500, ex.Message);
            }
        }
    }
}
