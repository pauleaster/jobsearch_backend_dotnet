namespace Jobsearch_backend.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class SearchTerm
    {
        [Column("term_id")]
        public required int SearchTermId { get; set; }

        [Column("term_text")]
        public required string SearchTermText { get; set; }

    }

}
