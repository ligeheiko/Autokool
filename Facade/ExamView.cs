using Autokool.Facade.Common;
using Facade.Common;
using System.ComponentModel;

namespace Facade
{
    public class ExamView : DateView
    {
        public bool Passed { get; set; }

        [DisplayName("Exam")]
        public string ExamTypeID { get; set; }

        [DisplayName("Exam")]
        public string ExamName { get; set; }
    }
}
