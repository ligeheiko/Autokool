using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.Factories
{
    [TestClass]
    public class CourseTypeViewFactoryTests : FactoryBaseTests<CourseTypeViewFactory, CourseTypeData, CourseType, CourseTypeView>
    {
        protected override CourseType createObject(CourseTypeData d) => new CourseType(d);
    }
}