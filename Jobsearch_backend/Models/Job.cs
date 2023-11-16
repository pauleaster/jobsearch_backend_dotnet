namespace Jobsearch_backend.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Job
    {
        [Column("job_id")]
        public int JobId { get; set; }

        // Other properties
    }

}
