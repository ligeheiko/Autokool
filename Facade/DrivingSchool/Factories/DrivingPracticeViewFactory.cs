using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class DrivingPracticeViewFactory : AbstractViewFactory<DrivingPracticeData, DrivingPractice, DrivingPracticeView>
    {
        protected internal override DrivingPractice toObject(DrivingPracticeData d) => new DrivingPractice(d);
    }
}
