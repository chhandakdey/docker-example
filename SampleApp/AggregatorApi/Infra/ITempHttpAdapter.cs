namespace AggregatorApi.Infra
{
    public interface ITempHttpAdapter
    {
        Task<int> GetResult();
    }
}
