using Facade.Common;
using System.ComponentModel;

namespace Facade
{
    public class ExamView : BaseView
    {
        public bool Passed { get; set; }

        [DisplayName("Exam")]
        public string ExamTypeID { get; set; }

        [DisplayName("Exam")]
        public string ExamName { get; set; }
    }
}
