using Autokool.Aids;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Infra;
using Autokool.Pages.Common;
using Autokool.Tests.InfraTests;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Tests.PagesTests
{
    public abstract class CommonPageTests<TPage,TBaseClass> : AbstractTests<TBaseClass>
        where TPage : PageModel, IUnifiedPage<TPage>
    {
        protected TPage page;
        protected string id;
        protected string sortOrder;
        protected string searchString;
        protected int pageIndex;
        protected string fixedFilter;
        protected string fixedValue;
        protected string currentFilter;
        protected int switchOfCreate;
        protected ApplicationDbContext appDb;
        protected virtual string expectedUrl => string.Empty;
        protected abstract List<string> expectedIndexTableColumns { get; }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            page = obj as TPage;
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
        [TestMethod]
        public void GetNameTest()
        {
            var length = expectedIndexTableColumns.Count;
            IHtmlHelper<TPage> htmlHelper = new MockHtmlHelper<TPage>();
            for (int index = 0; index < length; index++)
            {
                areEqual("Undefined", page.GetName(null, index));
                isTrue(page.GetName(htmlHelper, index).EndsWith(expectedIndexTableColumns[index]));
            }
            var indexOutOfLimits = GetRandom.Int32(length);
            areEqual("Undefined", page.GetName(null, indexOutOfLimits));
            areEqual("Undefined", page.GetName(htmlHelper, indexOutOfLimits));
        }
        [TestMethod]
        public void GetValueTest()
        {
            var length = expectedIndexTableColumns.Count;
            IHtmlHelper<TPage> htmlHelper = new MockHtmlHelper<TPage>();
            for (int index = 0; index < length; index++)
            {
                var expected = expectedIndexTableColumns[index];
                areEqual(default(IHtmlContent), page.GetValue(null, index));
                var c = page.GetValue(htmlHelper, index);
                if (c is not MockHtmlContent) c = new MockHtmlContent(c);
                validateValue((c as MockHtmlContent).Value, expected);
            }
            var indexOutOfLimits = GetRandom.Int32(length);
            areEqual(default(IHtmlContent), page.GetValue(null, indexOutOfLimits));
            areEqual(default(IHtmlContent), page.GetValue(htmlHelper, indexOutOfLimits));
        }
        protected async Task selectNameTest<TO>(IRepo<TO> repo, Func<string,string> func)
        {
            var list = await repo.Get();
            var idx = random(0, list.Count);
            dynamic obj = list[idx];
            areEqual(obj.Name, func(obj.ID));
        }
        protected IRepo<TObj> addItems<TObj, TData>(IRepo<TObj> repo, Func<TData, TObj> func)
        {
            var count = random(5, 10);
            for (int i = 0; i < count; i++)
            {
                repo.Add(func(random<TData>()));
            }
            return repo;
        }
        protected async Task selectListTest<TObj>(dynamic list, IRepo<TObj> repo)
        {
            areEqual((await repo.Get()).Count + 1, list.Count);
        }
        protected virtual void validateValue(string actual, string expected)
           => isTrue(actual.EndsWith(expected));
        protected void initInMemoryDatabase()
        {
            var im = new InMemoryApplicationDbContext();
            appDb = im.AppDb;
        }
    }
}