namespace Jobsearch_backend.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Job
    {
        [Column("job_id")]
        public required int JobId { get; set; }

        [Column("job_number")]
        public required int JobNumber { get; set; }

        [Column("job_url")]
        public required string JobUrl { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("comments")]
        public string? Comments { get; set; }

        [Column("requirements")]
        public string? Requirements { get; set; }

        [Column("follow_up")]
        public string? FollowUp { get; set; }

        [Column("highlight")]
        public string? Highlight { get; set; }

        [Column("applied")]
        public string? Applied { get; set; }

        [Column("contact")]
        public string? Contact { get; set; }

        [Column("application_comments")]
        public string? ApplicationComments { get; set; }

        [Column("job_date")]
        public DateTime? JobDate { get; set; }

        [Column("application_date")]
        public DateTime? ApplicationDate { get; set; }

        [Column("unsuccessful")]
        public string? Unsuccessful { get; set; }


        public override string ToString()
        {
            return $"job_id: {JobId}, job_number: {JobNumber}, job_url: {JobUrl}, title: {Title}, "
                   + $"comments: {Comments}, requirements: {Requirements}, follow_up: {FollowUp}, "
                   + $"highlight: {Highlight}, applied: {Applied}, contact: {Contact}, "
                   + $"application_comments: {ApplicationComments}, "
                   // Adjust the format for JobDate and ApplicationDate
                   + $"job_date: {JobDate?.ToString("dd/MM/yyyy")}, "
                   + $"application_date: {ApplicationDate?.ToString("dd/MM/yyyy")}, "
                   + $"unsuccessful: {Unsuccessful}";
        }

    }

}
