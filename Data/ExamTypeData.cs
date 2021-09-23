using Microsoft.EntityFrameworkCore;

namespace Data
{
    [Keyless]
    public class ExamTypeData
    {
        public string TheoryExam { get; set; }
        public string DrivingExam { get; set; }
    }
}
