using System.Collections.Generic;

namespace DotnetForJavaDevs.AsyncAndAwaitSample.Responses
{
    public class PagedResponse<T>
    {
        public int Count { get; set; }
        public ICollection<T> Results { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
    }
}