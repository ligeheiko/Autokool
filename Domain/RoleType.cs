using Autokool.Domain.Common;
using Autokool.Data.DrivingSchool;

namespace Autokool.Domain
{
    public sealed class RoleType : UniqueEntity<RoleTypeData>
    {
        public RoleType(RoleTypeData d = null) : base(d) { }

        public string AdministratorID => Data?.AdministratorID ?? Unspecified;
        public string StudentID => Data?.StudentID ?? Unspecified;
        public string TeacherID => Data?.TeacherID ?? Unspecified;
    }
}
