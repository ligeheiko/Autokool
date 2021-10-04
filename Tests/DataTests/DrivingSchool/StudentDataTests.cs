using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class StudentDataTests : BaseTests<StudentData, PersonData>
    {
        [TestMethod]
        public void CourseTest()
        {
            TestProperty<CourseData>(nameof(obj.Course));
        }
    }
}
