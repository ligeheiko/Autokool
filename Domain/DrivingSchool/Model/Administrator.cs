using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class Administrator : PersonEntity<AdministratorData>
    {
        public Administrator(AdministratorData d) : base(d) { }
    }
}
