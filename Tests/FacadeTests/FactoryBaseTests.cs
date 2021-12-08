using Autokool.Data.Common;
using Autokool.Domain.Common;
using Autokool.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests
{
    public abstract class FactoryBaseTests<TFactory, TData, TObject, TView> 
        : SealedTests<AbstractViewFactory<TData, TObject, TView>>
        where TData : BaseData, new()
        where TView : BaseView, new()
        where TObject : IUniqueEntity<TData>
        where TFactory : AbstractViewFactory<TData, TObject, TView>, new()
    {
        [TestMethod] public void CreateTest() { }
        [TestMethod]
        public void CreateObjectTest()
        {
            var v = random<TView>();
            var o = (obj as TFactory).Create(v);
            areEqualProperties(v, o.Data);
        }
        [TestMethod]
        public void CreateViewTest()
        {
            var d = random<TData>();
            var o = createObject(d);
            var v = (obj as TFactory).Create(o);
            areEqualProperties(d, v);
        }
        protected abstract TObject createObject(TData d);
    }
}
