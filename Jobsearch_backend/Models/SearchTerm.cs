namespace Jobsearch_backend.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class SearchTerm
    {
        [Column("term_id")]
        public required int TermId { get; set; }

        [Column("term_text")]
        public required int TermText { get; set; }

    }

}
