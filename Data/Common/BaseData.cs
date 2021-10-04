using Autokool.Core;
using System;

namespace Autokool.Data.Common
{
    public class BaseData : IEntityData
    {
        public string ID { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
