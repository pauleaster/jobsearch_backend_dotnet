namespace Jobsearch_backend.Models
{
    public class JobAllowablePatchFields
    {
        public static readonly Dictionary<string, Type> Fields = new()
        {
            { "job_url", typeof(string) },
            { "title", typeof(string) },
            { "comments", typeof(string) },
            { "requirements", typeof(string) },
            { "follow_up", typeof(string) },
            { "highlight", typeof(string) },
            { "applied", typeof(string) },
            { "contact", typeof(string) },
            { "application_comments", typeof(string) },
        };


        // Check to see if the field name is in the list of allowable fields
        // using a static method with GetFields and BindingFlags methods
        private static bool IsAllowableField(string? fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return false; // Or handle it in a way that makes sense for your application
            }

            return Fields.ContainsKey(fieldName);
        }

        // This is called after IsAllowableField
        // so that we already know that the field is value
        // we only need to check the data type of object? value
        private static bool IsValidDataType( string fieldName, object? value)
            
        {
            // job_url cannot be null
            if (fieldName == "job_url" && value == null)
            {
                return false;
            } 
            else if (value == null) // other fields can be null
            {
                return true; 
            }
            else
                return value.GetType() == Fields[fieldName];
        }

        public static bool ValidFieldAndData(string? fieldName, object? value)
        {


            if (IsAllowableField(fieldName) == false)
            {
                return false;
            }
            else // fieldName is not null
            {
                return IsValidDataType(fieldName!, value);
            }
        }
        
       

        
    }


   

}
