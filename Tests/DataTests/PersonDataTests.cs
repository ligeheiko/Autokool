using Data;
using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests
{
    [TestClass]
    public class PersonDataTests : BaseTests<PersonData, BaseData>
    {
        [TestMethod]
        public void FirstNameTest()
        {
            TestProperty<string>(nameof(obj.FirstName));
        }
        [TestMethod]
        public void LastNameTest()
        {
            TestProperty<string>(nameof(obj.LastName));
        }
        [TestMethod]
        public void EmailTest()
        {
            TestProperty<string>(nameof(obj.Email));
        }
        [TestMethod]
        public void PhoneNrTest()
        {
            TestProperty<string>(nameof(obj.PhoneNr));
        }
    }
}
