using Autokool.Aids;
using Autokool.Data.Common;
using Autokool.Domain.Common;

namespace Autokool.Facade.Common
{
    public abstract class AbstractViewFactory<TData, TObject, TView>
        where TData : BaseData, new()
        where TView : BaseView, new()
        where TObject : IUniqueEntity<TData>
    {
        public TObject Create(TView v)
        {
            var d = new TData();
            Copy.Members(v, d);
            return toObject(d);
        }
        internal protected abstract TObject toObject(TData d);

        public TView Create(TObject o)
        {
            var v = new TView();
            Copy.Members(o.Data, v);
            return v;
        }
    }
}
