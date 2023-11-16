using Jobsearch_backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace Jobsearch_backend.Controllers
{
    public class JobsController : ControllerBase
    {
        private readonly JobsearchDbContext _dbContext;

        public JobsController(JobsearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Now you can use _dbContext in your controller actions
    }
}
