using System.ComponentModel;

namespace Autokool.Facade.DrivingSchool.ViewModels
{
    public sealed class RegisterExamView : RegisterView
    {
        [DisplayName("Exam Name")]
        public string ExamID { get; set; }
    }
}