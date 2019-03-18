using Newtonsoft.Json;

namespace Infrastructure.TSDB.Grouping
{
    public class GroupByValue : GroupBy
    {
        [JsonProperty("range_size")]
        public int RangeSize { get; private set; }

        public GroupByValue(int rangeSize) : base("value")
        {
            RangeSize = rangeSize;
        }
    }
}