namespace AggregatorApi.Infra
{
    public interface IHumidHttpAdapter
    {
        Task<int> GetResult();
    }
}
