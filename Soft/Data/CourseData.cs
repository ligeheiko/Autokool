using Soft.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soft.Data
{
    public class CourseData : BaseData
    {
        public string Location { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
    }
}
