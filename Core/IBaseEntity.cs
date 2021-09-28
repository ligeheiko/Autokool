using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IBaseEntity
    {
        public string ID { get; }
        public DateTime ValidFrom { get; }
        public DateTime ValidTo { get; }
    }
}
