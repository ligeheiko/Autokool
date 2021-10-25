using System;

namespace Autokool.Core
{
    public interface IEntityData : IBaseEntity
    {
        public new string ID { get; set; }
    }
}
