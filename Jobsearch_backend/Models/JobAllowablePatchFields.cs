using System.Reflection;

namespace Jobsearch_backend.Models
{
    public class JobAllowablePatchFields
    {
        public string JobUrl = "job_url";
        public string Title = "title";
        public string Comments = "comments";
        public string Requirements = "requirements";
        public string FollowUp = "follow_up";
        public string Highlight = "highlight";
        public string Applied = "applied";
        public string Contact = "contact";
        public string ApplicationComments = "application_comments";

        // Check to see if the field name is in the list of allowable fields
        // using a static method with GetFields and BindingFlags methods
        public static bool IsAllowableField(string fieldName)
        {
            var fields = typeof(JobAllowablePatchFields)
                .GetFields(BindingFlags.Public |
                        BindingFlags.Static |
                        BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly);
            return fields.Any(fi =>
            {
                var value = fi.GetValue(null);
                if (value == null)
                    continue;
                else
                {
                    var valToString = value.ToString();
                    if (valToString == null)
                        return false;
                    else
                    {
                        return valToString.Equals(fieldName, StringComparison.OrdinalIgnoreCase);
                    }
                }
            });

        }
       

        
    }


   

}
