using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class TeacherTests : SealedTests<PersonEntity<TeacherData>>
    {
        private TeacherData data;
        protected override object createObject()
        {
            return new Teacher(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<TeacherData>();
            base.TestInitialize();
        }
        [TestMethod]
        public void StudentIDTest() => isProperty(data.StudentID);
    }
}
