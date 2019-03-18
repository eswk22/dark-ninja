using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.TSDB.Response;

namespace Infrastructure.TSDB
{
    public interface IKairosClient
    {
        Task AddMetricsAsync(IEnumerable<Metric> metrics);
        Task<QueryResponse> QueryMetricsAsync(QueryBuilder query);
    }
}