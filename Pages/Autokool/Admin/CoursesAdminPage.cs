using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Admin
{
    public class CoursesAdminPage : CoursesBasePage<CoursesAdminPage>
    {
        public CoursesAdminPage(ICourseRepo c, ICourseTypeRepo ct) : base(c, ct) { }
        protected override Uri pageUrl() => new Uri("/Administrator/Courses", UriKind.Relative);
    }
}
