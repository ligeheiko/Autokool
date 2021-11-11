using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class SchoolViewFactory : AbstractViewFactory<SchoolData, School, SchoolView>
    {
        protected internal override School toObject(SchoolData d) => new School(d);
    }
}
