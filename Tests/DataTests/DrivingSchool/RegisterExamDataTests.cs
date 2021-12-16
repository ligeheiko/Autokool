using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class RegisterExamDataTests : SealedTests<RegisterData>
    {
        [TestMethod]
        public void ExamIDTest()
        {
            isProperty<string>();
        }
    }
}