
namespace Autokool.Domain.Common
{
    public interface IUniqueEntity
    {
        string ID { get; }
        bool IsUnspecified { get; }
    }
    public interface IUniqueEntity<out TData> : IUniqueEntity
    {
        TData Data { get; }
    }
}
