namespace Jobsearch_backend.Exceptions
{   
    using System;
    public class NotFoundException(string message) : Exception(message)
    {
    }
}
