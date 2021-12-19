using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.Factories
{
    [TestClass]
    public class RegisterDrivingPracticeViewFactoryTests : FactoryBaseTests<RegisterDrivingPracticeViewFactory, RegisterDrivingPracticeData, RegisterDrivingPractice, RegisterDrivingPracticeView>
    {
        protected override RegisterDrivingPractice createObject(RegisterDrivingPracticeData d) => new RegisterDrivingPractice(d);
    }
}