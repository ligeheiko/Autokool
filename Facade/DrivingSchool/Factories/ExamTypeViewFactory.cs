using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class ExamTypeViewFactory : AbstractViewFactory<ExamTypeData, ExamType, ExamTypeView>
    {
        protected internal override ExamType toObject(ExamTypeData d) => new (d);
    }
}
