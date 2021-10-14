using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.Repos;

namespace Autokool.Domain
{
    public sealed class Exam : BaseEntity<ExamData>
    {
        public bool Passed => Data?.Passed ?? default;
        public string ExamTypeID => Data?.ExamTypeID ?? "Unspecified";
        //public ExamType ExamType = new GetFrom<IExamTypeRepo, ExamType>().ById(ExamTypeID);
    }
}
