using System;

namespace Autokool.Domain.Common
{
    public interface IDateEntity : IUniqueEntity
    {
        DateTime ValidFrom { get; }
        DateTime ValidTo { get; }

        bool IsUnspecified { get; }
    }
    public interface IDateEntity<out TData> : IUniqueEntity
    {
    }
}
