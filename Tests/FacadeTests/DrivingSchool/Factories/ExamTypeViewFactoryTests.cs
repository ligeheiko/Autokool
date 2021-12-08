using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.Factories
{
    [TestClass]
    public class ExamTypeViewFactoryTests : FactoryBaseTests<ExamTypeViewFactory, ExamTypeData, ExamType, ExamTypeView>
    {
        protected override ExamType createObject(ExamTypeData d) => new ExamType(d);
    }
}