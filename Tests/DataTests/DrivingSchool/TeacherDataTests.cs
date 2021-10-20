using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class TeacherDataTests : SealedTests<PersonData>
    {
        [TestMethod]
        public void StudentTest()
        {
            isProperty<List<StudentData>>();
        }
    }
}
