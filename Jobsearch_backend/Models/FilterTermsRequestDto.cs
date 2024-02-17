namespace Jobsearch_backend.Models
{
    using Newtonsoft.Json;
    public class FilterTermsRequestDto
    {
        [JsonProperty("filterTerms")]
        public List<string> FilterTerms { get; set; }

        [JsonProperty("currentJobs")]
        public bool? CurrentJobs { get; set; }

        [JsonProperty("appliedJobs")]
        public bool? AppliedJobs { get; set; }

        public override string ToString()
        {
            return $"FilterTerms: [{string.Join(", ", FilterTerms)}]";
        }

    }

    
}