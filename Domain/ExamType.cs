using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;

namespace Autokool.Domain
{
    public sealed class ExamType : UniqueEntity<ExamTypeData>
    {
        public ExamType(ExamTypeData d = null) : base(d) { }
        public string TheoryExam => Data?.TheoryExam ?? Unspecified;
        public string DrivingExam => Data?.DrivingExam ?? Unspecified;
    }
}