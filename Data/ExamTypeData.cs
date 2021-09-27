using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ExamTypeData
    {
        public string ID { get; set; }
        public string TheoryExam { get; set; }
        public string DrivingExam { get; set; }
    }
}
