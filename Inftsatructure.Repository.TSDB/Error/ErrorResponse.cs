using System.Collections.Generic;

namespace Infrastructure.TSDB.Error
{
    /// <summary>
    /// response object from kairosdb when an error occurs
    /// </summary>
    public class ErrorResponse
    {
        public IEnumerable<string> Errors { get; set; } 
    }
}