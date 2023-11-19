namespace Jobsearch_backend.Models
{
    public class SearchTermDto
    {
        public required int TermId { get; set; }
        public required int TermText { get; set; }
        public override string ToString()
        {
            return $"TermId: {TermId}, TermText: {TermText}";
        }

    }

    
}