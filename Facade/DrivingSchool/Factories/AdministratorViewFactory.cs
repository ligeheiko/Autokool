using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class AdministratorViewFactory : AbstractViewFactory<AdministratorData, Administrator, AdministratorView>
    {
        protected internal override Administrator toObject(AdministratorData d) => new Administrator(d);
    }
}
