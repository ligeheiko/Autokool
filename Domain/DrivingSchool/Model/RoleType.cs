using Autokool.Domain.Common;
using Autokool.Data.DrivingSchool;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class RoleType : NamedEntity<RoleTypeData>
    {
        public RoleType(RoleTypeData d = null) : base(d) { }

    }
}
