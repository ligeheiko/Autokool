using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class DrivingPracticeDataTests : SealedTests<DateData>
    {
        [TestMethod]
        public void TeacherIDTest()
        {
            isProperty<string>();
        }
    }
}
