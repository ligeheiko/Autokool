using Autokool.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokool.Domain.Common
{
    public abstract class NamedEntity<T> : UniqueEntity<T>, INamedEntity<T> where T : NamedEntityData, new()
    {
        protected internal NamedEntity(T d = null) : base(d) { }

        public virtual string Name => Data?.Name ?? Unspecified;
    }
}
