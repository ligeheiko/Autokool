using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Facade.Common;

namespace Autokool.Facade.DrivingSchool
{
    public sealed class ExamTypeViewFactory : AbstractViewFactory<ExamTypeData, ExamType, ExamTypeView>
    {
        protected internal override ExamType toObject(ExamTypeData d) => new ExamType(d);
    }
}
