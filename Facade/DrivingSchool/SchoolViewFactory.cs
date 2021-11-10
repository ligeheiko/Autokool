using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;

namespace Autokool.Facade.DrivingSchool
{
    public sealed class SchoolViewFactory : AbstractViewFactory<SchoolData, School, SchoolView>
    {
        protected internal override School toObject(SchoolData d) => new School(d);
    }
}
