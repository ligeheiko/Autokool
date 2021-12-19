using Autokool.Data.Common;

namespace Autokool.Data.DrivingSchool
{
    public sealed class RegisterDrivingPracticeData :RegisterData
    {
        public string DrivingPracticeID { get; set; }
        public string TeacherID { get; set; }
    }
}