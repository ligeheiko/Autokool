using Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool
{
    public class ExamTypeView : BaseView
    {
        [DisplayName("Theory Exam")]
        public string TheoryExam { get; set; }
        [DisplayName("Driving Exam")]
        public string DrivingExam { get; set; }
    }
}
