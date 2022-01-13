using System;

namespace Autokool.Data.Common
{
    public abstract class BaseData
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
    }
}
