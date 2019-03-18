namespace Infrastructure.TSDB.Response
{
    public class TypedDatapoint<T>
    {
        public long TimeStamp { get; set; }
        public T Value { get; set; }
    }
}