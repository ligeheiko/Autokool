using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;
using Autokool.Domain.DrivingSchool.Repos;

namespace Autokool.Domain.DrivingSchool.Model
{
    public sealed class RegisterExam : RegisterEntity<RegisterExamData>
    {
        public RegisterExam(RegisterExamData d) : base(d) { }
        public string ExamID => Data?.ExamID ?? Unspecified;
        public Exam Exam => new GetFrom<IExamRepo, Exam>()?.ById(ExamID);
    }
}