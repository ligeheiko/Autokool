using System;

namespace Autokool.Core
{
    public interface IBaseEntity
    {
        public string ID { get; }
        public DateTime ValidFrom { get; }
        public DateTime ValidTo { get; }
    }
}
