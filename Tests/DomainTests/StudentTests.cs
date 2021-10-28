using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests
{
    [TestClass]
    public class StudentTests : SealedTests<PersonEntity<StudentData>>
    {
        private StudentData data;
        protected override object createObject()
        {
            return new Student(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<StudentData>();
            base.TestInitialize();
        }
        [TestMethod]
        public void CourseIDTest() => isProperty(data.CourseID);
    
    }
}
