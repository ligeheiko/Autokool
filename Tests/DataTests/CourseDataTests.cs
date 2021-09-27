using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests
{
    [TestClass]
    public class CourseDataTests : BaseTests<CourseData, BaseData>
    {
        [TestMethod]
        public void LocationTest()
        {
            TestProperty<string>(nameof(obj.Location));
        }
        [TestMethod]
        public void ClassTypesTest()
        {
            TestProperty<string>(nameof(obj.CourseTypeID));
        }
    }
}
