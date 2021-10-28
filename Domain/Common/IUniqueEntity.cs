
namespace Autokool.Domain.Common
{
    public interface IUniqueEntity
    {
        string ID { get; }
    }
    public interface IUniqueEntity<out TData> : IUniqueEntity
    {
        TData Data { get; }
    }
}
