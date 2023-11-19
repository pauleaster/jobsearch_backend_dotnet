using Jobsearch_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jobsearch_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController(IJobService jobService) : ControllerBase
    {
        private readonly IJobService _jobService = jobService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            Debug.WriteLine(job);
            return Ok(job);
        }

        [HttpGet("{id}/html")]
        public async Task<IActionResult> GetJobHtmlData(int id)
        {
            var jobHtml = await _jobService.GetJobHtmlDataByIdAsync(id);
            if (jobHtml == null)
            {
                return NotFound();
            }
            Debug.WriteLine(jobHtml);
            return Content(jobHtml, "text/html");
        }
    }
}
