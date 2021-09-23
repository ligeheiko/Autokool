using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tests;

namespace Autokool.Tests.DataTests
{
    [TestClass]
    public class TeacherDataTests : BaseTests<TeacherData, PersonRoleData>
    {
        [TestMethod]
        public void StudentTest()
        {
            TestProperty<List<StudentData>>(nameof(obj.Student));
        }
    }
}
