using Autokool.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autokool.Tests.FacadeTests.DrivingSchool.ViewModels
{
    [TestClass]
    public class CourseViewTests : SealedTests<DateView>
    {
        [TestMethod]
        public void LocationTest() => isDisplayProperty<string>("Location");
        [TestMethod]
        public void CourseTypeIDTest() => isDisplayProperty<string>("Course Type");
        [TestMethod]
        public void RegisterCourseIDTest() => isDisplayProperty<string>("RegisterID");
        [TestMethod]
        public void ValidFromTest() => isDateProperty<DateTime?>("Added");
        [TestMethod]
        public void ValidToTest() => isDisplayProperty<DateTime?>("Every week at");
    }
}
