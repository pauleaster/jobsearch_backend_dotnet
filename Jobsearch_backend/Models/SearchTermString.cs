namespace Jobsearch_backend.Models
{
    public class SearchTermString
    {
        public List<string> Terms { get; set; } = [];

        private static readonly char[] separator = [',', ' '];

        // Returns terms as a single comma-separated string
        public override string ToString()
        {
            return string.Join(", ", Terms);
        }

        // Adds terms from a comma-separated string
        public void AddTermsFromString(string termsString)
        {
            var terms = termsString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Terms.AddRange(terms);
        }

        public bool Contains(string term)
        {
            return Terms.Contains(term);
        }

        private const string Delimiter = "|"; // Using the pipe symbol as a delimiter

        public string ToDelimitedString()
        {
            // Encapsulate each term with the delimiter
            var delimitedTerms = Terms.Select(term => $"{Delimiter}{term}{Delimiter}");
            return string.Join("", delimitedTerms); // Join without any spaces
        }
    }

}