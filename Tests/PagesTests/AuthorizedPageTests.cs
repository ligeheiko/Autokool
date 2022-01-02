using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autokool.Tests.PagesTests
{
    [TestClass]
    public abstract class AuthorizedPageTests<TBaseClass> : SealedTests<TBaseClass>
    {
        protected string id;
        protected string sortOrder;
        protected string searchString;
        protected int pageIndex;
        protected string fixedFilter;
        protected string fixedValue;
        protected string currentFilter;
        protected int switchOfCreate;
        protected virtual string expectedUrl => string.Empty;
        protected abstract List<string> expectedIndexTableColumns { get; }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            id = Guid.NewGuid().ToString();
            sortOrder = random<string>();
            searchString = random<string>();
            pageIndex = random<int>();
            switchOfCreate = random<int>();
            currentFilter = random<string>();
            fixedFilter = random<string>();
            fixedValue = random<string>();
        }
        [TestMethod]
        public void IsAuthorizedTest()
        {
            var type = objUnderTests.GetType();
            var list = type?.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            var a = list?.Cast<AuthorizeAttribute>().Single();
            if (a is null)
            {
                isFalse(true, $"Class {type.Name} does not have authorization");
            }
        }
        [TestMethod]
        public void TableColumnsTest()
        {
            var expectedCount = expectedIndexTableColumns.Count;
            var pi = objUnderTests?.GetType()?.GetProperty("Columns");
            dynamic c = pi?.GetValue(objUnderTests);
            areEqual(expectedCount, c.Count);
            for (var i = 0; i < expectedCount; i++)
                isTrue(c[i].ToString().EndsWith(expectedIndexTableColumns[i]));
        }
        [TestMethod]
        public void PageUrlTest()
        {
            if (expectedUrl == string.Empty) notTested();
            var pi = objUnderTests?.GetType()?.GetProperty("PageUrl");
            var expected = pi?.GetValue(objUnderTests).ToString();
            areEqual(expectedUrl, expected);
        }
    }
}
