using Autokool.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.DataTests.Common
{
    [TestClass]
    public class ApplicationUserTests : SealedTests<IdentityUser>
    {
        [TestMethod]
        public void IdTest()
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
        public void EmailTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void UserNameTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void PhoneNumberTest()
        {
            isProperty<string>();
        }
        [TestMethod]
        public void ProfilePictureTest()
        {
            isProperty<byte[]>();
        }
    }
}
