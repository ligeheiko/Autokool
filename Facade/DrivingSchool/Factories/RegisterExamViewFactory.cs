using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;

namespace Autokool.Facade.DrivingSchool.Factories
{
    public sealed class RegisterExamViewFactory : AbstractViewFactory<RegisterExamData, RegisterExam, RegisterExamView>
    {
        protected internal override RegisterExam toObject(RegisterExamData d) => new (d);
    }
}