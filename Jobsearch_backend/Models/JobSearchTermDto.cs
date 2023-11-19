namespace Jobsearch_backend.Models
{
    public class JobSearchTermDto
    {
        public required int JobId { get; set; }
        public required int TermId { get; set; }
        public required int Valid { get; set; }
        public override string ToString()
        {
            return $"JobId: {JobId}, TermId: {TermId}, valid: {Valid}";
        }

    }

    
}