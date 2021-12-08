using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.Factories
{
    [TestClass]
    public class DrivingPracticeViewFactoryTests : FactoryBaseTests<DrivingPracticeViewFactory, DrivingPracticeData, DrivingPractice, DrivingPracticeView>
    {
        protected override DrivingPractice createObject(DrivingPracticeData d) => new DrivingPractice(d);
    }
}