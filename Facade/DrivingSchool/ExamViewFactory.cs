using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;

namespace Autokool.Facade.DrivingSchool
{
    public sealed class ExamViewFactory : AbstractViewFactory<ExamData, Exam, ExamView>
    {
        protected internal override Exam toObject(ExamData d) => new Exam(d);
    }
}
