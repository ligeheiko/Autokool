using Autokool.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autokool.Tests.FacadeTests.DrivingSchool.ViewModels
{
    [TestClass]
    public class DrivingPracticeViewTests : SealedTests<DateView>
    {
        [TestMethod]
        public void TeacherIDTest() => isDisplayProperty<string>("Teacher's Name");
        [TestMethod]
        public void ValidFromTest() => isDisplayProperty<DateTime?>("Starts");
        [TestMethod]
        public void ValidToTest() => isDisplayProperty<DateTime?>("Ends");
    }
}
