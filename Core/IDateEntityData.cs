using System;

namespace Autokool.Core
{
    public interface IDateEntityData : IEntityData
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
