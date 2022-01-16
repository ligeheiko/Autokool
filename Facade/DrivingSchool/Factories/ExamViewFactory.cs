using Autokool.Data.DrivingSchool;
using Autokool.Domain;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class ExamViewFactory : AbstractViewFactory<ExamData, Exam, ExamView>
    {
        protected internal override Exam toObject(ExamData d) => new (d);
    }
}
