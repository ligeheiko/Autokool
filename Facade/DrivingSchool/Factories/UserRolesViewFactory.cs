using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class UserRolesViewFactory : AbstractViewFactory<UserRolesData, UserRoles, UserRolesView>
    {
        protected internal override UserRoles toObject(UserRolesData d) => new UserRoles(d);
    }
}
