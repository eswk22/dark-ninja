using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.TSDB.Response;

namespace Infrastructure.TSDB
{
    public interface IRestClient
    {
        Task AddMetricsAsync(Metric metric);
        Task AddMetricsAsync(IEnumerable<Metric> metrics);
        Task<QueryResponse> DeleteMetricAsync(string metric);
        Task<QueryResponse> DeleteMetricsAsync(QueryBuilder query);
        Task<QueryResponse> QueryMetricsAsync(QueryBuilder query);
    }
}