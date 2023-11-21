using Newtonsoft.Json;

namespace Jobsearch_backend.Models
{
    public class ValidJobSearchTermDto
    {
        [JsonProperty("job_id")]
        public required int JobId { get; set; }
        [JsonProperty("job_number")] 
        public required int JobNumber { get; set; }
        [JsonProperty("matching_terms")] 
        public required string MatchingSearchTerms { get; set; }
        public override string ToString()
        {
            return $"JobId: {JobId}, JobNumber: {JobNumber}, MatchingSearchTerms: {MatchingSearchTerms}";
        }

    }

    
}