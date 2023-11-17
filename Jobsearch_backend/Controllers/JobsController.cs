using Jobsearch_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jobsearch_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController(IJobService jobService) : ControllerBase
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

        // Additional actions can be added here
    }
}
