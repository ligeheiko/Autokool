using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class CourseTypeDataTests : SealedTests<NamedEntityData>
    {
        [TestMethod]
        public void IDTest()
        {
            isProperty<string>();
        }
    }
}
