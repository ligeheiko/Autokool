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
        protected override Teacher createObject(TeacherData d) => new Teacher(d);
    }
}