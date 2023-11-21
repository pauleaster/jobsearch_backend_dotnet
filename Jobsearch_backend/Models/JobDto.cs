using Newtonsoft.Json;

namespace Jobsearch_backend.Models
{
    public class JobDto
    {
        [JsonProperty("job_id")]
        public required int JobId { get; set; }
        
        [JsonProperty("job_number")]
        public required int JobNumber { get; set; }
        
        [JsonProperty("job_url")]
        public string? JobUrl { get; set; }
        
        [JsonProperty("title")]
        public string? Title { get; set; }
        
        [JsonProperty("comments")]
        public string? Comments { get; set; }
        
        [JsonProperty("requirements")]
        public string? Requirements { get; set; }
        
        [JsonProperty("follow_up")]
        public string? FollowUp { get; set; }
        
        [JsonProperty("highlight")]
        public string? Highlight { get; set; }
        
        [JsonProperty("applied")]
        public string? Applied { get; set; }
        
        [JsonProperty("contact")]
        public string? Contact { get; set; }
        
        [JsonProperty("application_comments")]
        public string? ApplicationComments { get; set; }

        public override string ToString()
        {
            return $"JobId: {JobId}, JobNumber: {JobNumber}, JobUrl: {JobUrl}, Title: {Title}, "
                    + $"Comments: {Comments}, Requirements: {Requirements}, FollowUp: {FollowUp}, "
                    + $"Highlight: {Highlight}, Applied: {Applied}, Contact: {Contact}, "
                    + $"ApplicationComments: {ApplicationComments}";
        }

    }

    
}