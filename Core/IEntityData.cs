using System;

namespace Autokool.Core
{
    public interface IEntityData : IBaseEntity
    {
        public new  string ID { get; set; }
        public new DateTime ValidFrom { get; set; }
        public new DateTime ValidTo { get; set; }
    }
}
