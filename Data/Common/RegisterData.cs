using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokool.Data.Common
{
    public class RegisterData : BaseData
    {
        public string UserId { get; set; }
        public string CourseID { get; set; }
        public bool IsRegisteredCourse { get; set; }
    }
}
