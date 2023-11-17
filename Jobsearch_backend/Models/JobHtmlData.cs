namespace Jobsearch_backend.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class JobHtmlData    
    {
        [Column("job_id")]
        public required int JobId { get; set; }

        [Column("job_html")]
        public string? JobHtml { get; set; }

    }

}
