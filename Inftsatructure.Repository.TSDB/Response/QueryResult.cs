using System.Collections.Generic;

namespace Infrastructure.TSDB.Response
{
    public class QueryResponse
    {
        public List<Query> Queries { get; set; }
    }
}
