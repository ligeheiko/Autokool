using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.Factories
{
    [TestClass]
    public class TeacherViewFactoryTests : FactoryBaseTests<TeacherViewFactory, TeacherData, Teacher, TeacherView>
    {
        protected override string[] excludeProperties => new string[] {"FullName","RoleTypeID" };
        protected override Teacher createObject(TeacherData d) => new Teacher(d);
        protected override void doAfterCreateViewTest(Teacher o, TeacherView v)
        {
            areEqual(o.FullName, v.FullName);
        }
    }
}