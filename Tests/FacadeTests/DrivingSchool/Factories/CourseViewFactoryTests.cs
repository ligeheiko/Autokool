using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.Factories
{
    [TestClass]
    public class CourseViewFactoryTests : FactoryBaseTests<CourseViewFactory, CourseData, Course, CourseView>
    {
        protected override Course createObject(CourseData d) => new Course(d);
    }
}
