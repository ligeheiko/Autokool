using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.Factories
{
    [TestClass]
    public class RegisterExamViewFactoryTests : FactoryBaseTests<RegisterExamViewFactory, RegisterExamData, RegisterExam, RegisterExamView>
    {
        protected override RegisterExam createObject(RegisterExamData d) => new RegisterExam(d);
    }
}