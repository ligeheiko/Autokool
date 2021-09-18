﻿using Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;

namespace Autokool.Tests.DataTests
{
    [TestClass]
    public class BaseDataTests : BaseTests<BaseData, object>
    {
        [TestMethod]
        public void IDTest()
        {
            TestProperty(x => obj.ID = x, () => obj.ID);
        }
    }
}
