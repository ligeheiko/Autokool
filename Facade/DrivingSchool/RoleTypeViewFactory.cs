using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;

namespace Autokool.Facade.DrivingSchool
{
    public sealed class RoleTypeViewFactory : AbstractViewFactory<RoleTypeData, RoleType, RoleTypeView>
    {
        protected internal override RoleType toObject(RoleTypeData d) => new RoleType(d);
    }
}
