using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Autokool.Tests.DataTests.DrivingSchool
{
    [TestClass]
    public class UserRolesDataTests : SealedTests<BaseData>
    {
        [TestMethod]
        public void UserIdTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void FirstNameTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void LastNameTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void UserNameTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void EmailTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void RolesTest()
        {
            isProperty<IEnumerable<string>>();
        }
    }
}
