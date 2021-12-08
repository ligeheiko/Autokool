using Autokool.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autokool.Tests.FacadeTests.DrivingSchool.ViewModels
{
    [TestClass]
    public class ExamViewTests : SealedTests<DateView>
    {
        [TestMethod]
        public void ExamTypeIDTest() => isDisplayProperty<string>("Exam Type");
        [TestMethod]
        public void ValidFromTest() => isDateProperty<DateTime?>("Added");
        [TestMethod]
        public void ValidToTest() => isDisplayProperty<DateTime?>("Starts");
    }
}