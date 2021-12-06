using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;

namespace Autokool.Pages.Autokool.Admin
{
    [Authorize(Roles = "Teacher, Administrator")]
    public class TeachersAdminPage : TeachersBasePage<TeachersAdminPage>
    {
        public TeachersAdminPage(ITeacherRepo t/*, IStudentRepo s*/) : base(t/*, s*/) { }
    }
}
