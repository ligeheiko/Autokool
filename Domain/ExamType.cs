using Autokool.Data.DrivingSchool;
using Autokool.Domain.Common;

namespace Autokool.Domain
{
    public sealed class ExamType : NamedEntity<ExamTypeData>
    {
        public ExamType(ExamTypeData d = null) : base(d) { }
    }
}