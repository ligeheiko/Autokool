using Autokool.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.DrivingSchool.ViewModels
{
    [TestClass]
    public class RegisterExamViewTests : SealedTests<RegisterView>
    {
        [TestMethod]
        public void ExamIDTest() => isDisplayProperty<string>("Exam Name");
    }
}