using Autokool.Data.Common;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class RegisterViewFactory: AbstractViewFactory<RegisterData, Register, RegisterView>
    {
        protected internal override Register toObject(RegisterData d) => new Register(d);
    }
}