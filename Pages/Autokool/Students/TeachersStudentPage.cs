using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Pages.Autokool.Base;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Autokool.Pages.Autokool.Students
{
    [Authorize(Roles = "Student")]
    public sealed class TeachersStudentPage : TeachersBasePage<TeachersStudentPage>
    {
        public TeachersStudentPage(ITeacherRepo t) : base(t) { }
        protected override Uri pageUrl() => new Uri("/Student/Teachers", UriKind.Relative);
        protected override void createTableColumns()
        {
            createColumn(x => Item.FullName);
            createColumn(x => Item.Email);
            createColumn(x => Item.PhoneNr);
        }
    }
}