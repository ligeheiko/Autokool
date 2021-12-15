using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Autokool.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Pages.Autokool.Admin
{
    public class RegisteredUsersAdminPage : ViewPage<RegisteredUsersAdminPage, IRegisterRepo, Register, RegisterView, RegisterData>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public IEnumerable<SelectListItem> Courses { get; }
        public RegisteredUsersAdminPage(IRegisterRepo r,ICourseRepo c , UserManager<ApplicationUser> userManager) : base(r, "Registered Users") 
        {
            Courses = newItemsList<Course, CourseData>(c);
            _userManager = userManager;
        }
        protected override Uri pageUrl() => new Uri("/Administrator/Registered", UriKind.Relative);
        public string CourseName(string id) => itemName(Courses, id);
        protected internal override Register toObject(RegisterView v) => new RegisterViewFactory().Create(v);
        protected internal override RegisterView toView(Register o) => new RegisterViewFactory().Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.CourseID);
            createColumn(x => Item.UserId);
            createColumn(x => Item.UserName);
        }
        public override IHtmlContent GetValue(IHtmlHelper<RegisteredUsersAdminPage> html, int i)
        {
            return i switch
            {
                0 => getRaw(html, CourseName(Item.CourseID)),
                _ => base.GetValue(html, i)
            };
        }
    }
}
