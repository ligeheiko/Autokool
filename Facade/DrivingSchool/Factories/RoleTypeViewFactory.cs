using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class RoleTypeViewFactory : AbstractViewFactory<RoleTypeData, RoleType, RoleTypeView>
    {
        protected internal override RoleType toObject(RoleTypeData d) => new RoleType(d);
    }
}
