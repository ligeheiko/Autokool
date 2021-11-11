using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class SchoolTests : SealedTests<UniqueEntity<SchoolData>>
    {
        private SchoolData data;
        protected override object createObject()
        {
            return new School(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<SchoolData>();
            base.TestInitialize();
        }
        [TestMethod]
        public void AdministratorIDTest() => isProperty(data.AdministratorID);
        [TestMethod]
        public void CourseIDTest() => isProperty(data.CourseID);
        [TestMethod]
        public void StudentIDTest() => isProperty(data.StudentID);
        [TestMethod]
        public void TeacherIDTest() => isProperty(data.TeacherID);
    }
}
