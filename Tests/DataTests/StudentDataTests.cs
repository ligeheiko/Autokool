using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests
{
    [TestClass]
    public class StudentDataTests : BaseTests<StudentData, PersonRoleData>
    {
        [TestMethod]
        public void CourseTest()
        {
            TestProperty<CourseData>(nameof(obj.Course));
        }
    }
}
