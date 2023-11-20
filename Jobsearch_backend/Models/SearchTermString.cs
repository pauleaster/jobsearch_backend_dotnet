using System.Diagnostics;

namespace Jobsearch_backend.Models
{
    public class SearchTermString
    {
        public List<string> Terms { get; set; } = [];

        private static readonly char[] separator = [','];

        // Returns terms as a single comma-separated string
        public override string ToString()
        {
            return string.Join(", ", Terms);
        }

        // Adds terms from a comma-separated string
        public void AddTermsFromString(string termsString)
        {
            var terms = termsString.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                            .Select(term => term.Trim()); // trim whitespace from start and end of each term
            Terms.AddRange(terms);
        }

        public bool Contains(string term)
        {
            return Terms.Contains(term);
        }
        
        public string TermsListAsString()
        {
            // print '[' + ', '.join(self.terms) + ']'
            return $"[\n*{string.Join("*,\n*", Terms)}*\n]";
        }
        
        public string ToDelimitedString(char Delimiter)
        {
            Debug.WriteLine($"\nTerms: {TermsListAsString()}\n");
            Debug.WriteLine($"\n\nDelimiter: {Delimiter}\n\n");
            // Encapsulate each term with the delimiter
            var delimitedTerms = Terms.Select(term => $"{Delimiter}{term}{Delimiter}");
            return string.Join("", delimitedTerms); // Join without any spaces
        }
    }

}