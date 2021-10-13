using Autokool.Data.Common;

namespace Autokool.Data.DrivingSchool
{
    public sealed class ExamData : BaseData
    {
        public bool Passed { get; set; }
        public string ExamTypeID { get; set; }
        //public List<ExamTypeData> ExamType { get; set; }
    }
}
