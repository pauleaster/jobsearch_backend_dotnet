namespace Jobsearch_backend.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class JobSearchTerm
    {
        [Column("job_id")]
        public required int JobId { get; set; }

        [Column("term_id")]
        public required int SearchTermId { get; set; }

        [Column("valid")]
        public required int Valid { get; set; }

    }

}
