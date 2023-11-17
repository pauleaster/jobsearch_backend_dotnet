namespace Jobsearch_backend.Models
{
    public class JobHtmlDataDto
    {
        public required int JobId { get; set; }
        public string? JobHtml { get; set; }

        public override string ToString()
        {
            // Truncate JobHtml to 50 characters
            string? truncatedJobHtml = JobHtml?.Substring(0, 50);
            return $"JobId: {JobId}, JobHtml: {truncatedJobHtml}...";
        }

    }

    
}