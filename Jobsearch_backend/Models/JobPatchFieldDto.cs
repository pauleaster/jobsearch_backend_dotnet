namespace Jobsearch_backend.Models
{
    public class JobPatchFieldDto
    {
        public string Field { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"Field: {Field}, Value: {Value}";
        }

    }

    
}