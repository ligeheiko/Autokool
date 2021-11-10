using Autokool.Aids;
using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DomainTests
{
    [TestClass]
    public class CourseTypeTests : SealedTests<NamedEntity<CourseTypeData>>
    {
        private CourseTypeData data;
        protected override object createObject()
        {
            return new CourseType(data);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            data = GetRandom.ObjectOf<CourseTypeData>();
            base.TestInitialize();
        }
    }
}
