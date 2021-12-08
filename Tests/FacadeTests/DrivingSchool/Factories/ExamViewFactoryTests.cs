using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.DrivingSchool.Factories;
using Autokool.Facade.DrivingSchool.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.Factories
{
    [TestClass]
    public class ExamViewFactoryTests : FactoryBaseTests<ExamViewFactory, ExamData, Exam, ExamView>
    {
        protected override Exam createObject(ExamData d) => new Exam(d);
    }
}