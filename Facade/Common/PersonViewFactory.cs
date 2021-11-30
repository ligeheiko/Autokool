using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.Common
{
    public abstract class PersonViewFactory<TData, TObject, TView> : AbstractViewFactory<TData, TObject, TView>
        where TData : NamedEntityData, new()
        where TView : NamedView, new()
        where TObject : IUniqueEntity<TData>
    {
        public override TView Create(TObject o)
        {
            var v = base.Create(o);
            v.Name = GetName(v, o);
            return v;
        }
        public virtual string GetName(TView v, TObject o)
        {
            return v.Name;
        }
    }
}
