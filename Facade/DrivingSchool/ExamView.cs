using Autokool.Facade.Common;
using Facade.Common;
using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool
{
    public class ExamView : DateView
    {
        public bool Passed { get; set; }

        [DisplayName("Exam Type")]
        public string ExamTypeID { get; set; }

        [DisplayName("Exam Name")]
        public string ExamName { get; set; }
    }
}
