using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class Exam : DateEntity<ExamData>
    {
        public Exam(ExamData d) : base(d) { }
        public bool Passed => Data?.Passed ?? false;
        public string ExamTypeID => Data?.ExamTypeID ?? Unspecified;
        public ExamType ExamType => new GetFrom<IExamTypeRepo,ExamType>()?.ById(ExamTypeID);
    }
}
