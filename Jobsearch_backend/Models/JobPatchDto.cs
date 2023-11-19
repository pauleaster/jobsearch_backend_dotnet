namespace Jobsearch_backend.Models
{
    public class JobPatchDto
    {
        public required string? JobUrl { get; set; }
        public string? Title { get; set; }
        public string? Comments { get; set; }
        public string? Requirements { get; set; }
        public string? FollowUp { get; set; }
        public string? Highlight { get; set; }
        public string? Applied { get; set; }
        public string? Contact { get; set; }
        public string? ApplicationComments { get; set; }

        public override string ToString()
        {
            return $"JobUrl: {JobUrl}, Title: {Title}, "
                    + $"Comments: {Comments}, Requirements: {Requirements}, FollowUp: {FollowUp}, "
                    + $"Highlight: {Highlight}, Applied: {Applied}, Contact: {Contact}, "
                    + $"ApplicationComments: {ApplicationComments}";
        }

    }

    
}