using Autokool.Aids;
using Autokool.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests.Common
{
    [TestClass]
    public class PersonDataTests : AbstractTests<PersonData, BaseData>
    {
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
        public void EmailTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void PhoneNrTest()
        {
            isProperty<string>();
        }
    }
}
