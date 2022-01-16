using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class RegisterDrivingPracticeViewFactory : AbstractViewFactory<RegisterDrivingPracticeData, RegisterDrivingPractice, RegisterDrivingPracticeView>
    {
        protected internal override RegisterDrivingPractice toObject(RegisterDrivingPracticeData d) => new (d);
    }
}