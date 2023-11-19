namespace Jobsearch_backend.Models
{
    public class SearchTermDto
    {
        public required int SearchTermId { get; set; }
        public required string SearchTermText { get; set; }
        public override string ToString()
        {
            return $"TermId: {SearchTermId}, TermText: {SearchTermText}";
        }

    }

    
}