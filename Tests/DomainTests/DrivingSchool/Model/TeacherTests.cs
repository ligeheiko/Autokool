using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests.DrivingSchool.Model
{
    [TestClass]
    public class TeacherTests : SealedTests<PersonEntity<TeacherData>>
    {
        private TeacherData data;
        private Teacher teacher;
        protected override object createObject()
        {
            return new Teacher(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<TeacherData>();
            base.TestInitialize();
            teacher = obj as Teacher;
        }
    }
}
