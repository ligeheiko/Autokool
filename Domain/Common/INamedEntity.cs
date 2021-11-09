using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokool.Domain.Common
{
    public interface INamedEntity : IUniqueEntity
    {
        string Name { get; }
    }

    public interface INamedEntity<out TData> : INamedEntity, IUniqueEntity<TData> { }
}
