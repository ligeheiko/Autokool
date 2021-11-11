using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class PersonRoleViewFactory : AbstractViewFactory<PersonRoleData, PersonRole, PersonRoleView>
    {
        protected internal override PersonRole toObject(PersonRoleData d) => new PersonRole(d);
    }
}
