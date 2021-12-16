using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.Factories
{
    [TestClass]
    public class RegisterCourseViewFactoryTests : FactoryBaseTests<RegisterCourseViewFactory, RegisterCourseData, RegisterCourse, RegisterCourseView>
    {
        protected override RegisterCourse createObject(RegisterCourseData d) => new RegisterCourse(d);
    }
}
