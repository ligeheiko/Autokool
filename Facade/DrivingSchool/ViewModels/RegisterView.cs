using Autokool.Facade.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public sealed class RegisterView : BaseView
    {
        public string UserId { get; set; }
        public string CourseID { get; set; }
        public bool IsRegisteredCourse { get; set; }
    }
}
