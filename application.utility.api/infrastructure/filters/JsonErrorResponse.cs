using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.utility.api.infrastructure.filters
{
    public class JsonErrorResponse
    {
        public string[] Messages { get; set; }

        public object DeveloperMessage { get; set; }
    }
}
