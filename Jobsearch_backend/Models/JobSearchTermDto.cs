namespace Jobsearch_backend.Models
{
    public class JobSearchTermDto
    {
        public required int JobId { get; set; }
        public required int SearchTermId { get; set; }
        public required bool Valid { get; set; }
        public override string ToString()
        {
            return $"JobId: {JobId}, TermId: {SearchTermId}, valid: {Valid}";
        }

    }


}