using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokool.Tests.SoftTests
{
    [TestClass]
    public class BaseWebPageTests : TestAssertions
    {
        [TestMethod]
        public void SendRequestTest()
        {
            dynamic html = validateRequest("/Index");
            notTested();
        }

        private dynamic validateRequest(string url)
        {
            throw new NotImplementedException();
        }
    }
}
