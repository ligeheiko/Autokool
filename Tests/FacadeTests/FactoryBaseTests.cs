using Autokool.Aids;
using Autokool.Data.Common;
using Autokool.Domain.Common;
using Autokool.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Autokool.Tests.FacadeTests
{
    public abstract class FactoryBaseTests<TFactory, TData, TObject, TView> 
        : SealedTests<AbstractViewFactory<TData, TObject, TView>>
        where TData : BaseData, new()
        where TView : BaseView, new()
        where TObject : IUniqueEntity<TData>
        where TFactory : AbstractViewFactory<TData, TObject, TView>, new()
    {
        protected virtual string[] excludeProperties => Array.Empty<string>();
        [TestMethod] public void CreateTest() { }
        [TestMethod]
        public void CreateObjectTest()
        {
            var v = random<TView>();
            doBeforeCreateObjectTest(v);
            var o = (obj as TFactory).Create(v);
            areEqualProperties(v, o.Data, excludeProperties);
            doAfterCreateObjectTest(v, o);
        }
        [TestMethod]
        public void CreateViewTest()
        {
            var d = GetRandom.ObjectOf<TData>();
            //var d = random<TData>();
            doBeforeCreateViewTest(d);
            var o = createObject(d);
            var v = (obj as TFactory).Create(o);
            areEqualProperties(d, v, excludeProperties);
            doAfterCreateViewTest(o, v);
        }
        protected virtual void doAfterCreateViewTest(TObject o, TView v) { }
        protected virtual void doAfterCreateObjectTest(TView v, TObject o) { }
        protected virtual void doBeforeCreateViewTest(TData d) { }
        protected virtual void doBeforeCreateObjectTest(TView v) { }
        protected abstract TObject createObject(TData d);
    }
}