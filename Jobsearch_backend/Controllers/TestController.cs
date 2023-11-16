using Jobsearch_backend.Data;
using Jobsearch_backend.Tests;
using Microsoft.AspNetCore.Mvc;

namespace Jobsearch_backend.Controllers
{
    public class TestController : ControllerBase
    {
        private readonly JobsearchDbContext _dbContext;

        public TestController(JobsearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("test-db-connection")]
        public IActionResult TestDbConnection()
        {
            var dbTest = new DatabaseConnectivityTests(_dbContext);
            dbTest.TestDatabaseConnection();
            return Ok("Test completed. Check console output.");
        }
    }

}
