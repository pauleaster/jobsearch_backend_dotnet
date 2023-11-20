namespace Jobsearch_backend.Models
{
    public class ValidJobSearchTermDto
    {
        public required int JobId { get; set; }
        public required int JobNumber { get; set; }
        public required string MatchingSearchTerms { get; set; }
        public override string ToString()
        {
            return $"JobId: {JobId}, JobNumber: {JobNumber}, MatchingSearchTerms: {MatchingSearchTerms}";
        }

    }

    
}