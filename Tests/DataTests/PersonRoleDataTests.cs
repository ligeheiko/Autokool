﻿using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Autokool.Tests.DataTests
{
    [TestClass]
    public class PersonRoleDataTests : BaseTests<PersonRoleData, BaseData>
    {
        [TestMethod]
        public void PersonIDTest()
        {
            TestProperty<string>(nameof(obj.PersonID));
        }
    }
}
